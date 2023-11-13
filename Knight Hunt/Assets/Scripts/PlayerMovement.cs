using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float moveMultiplier;
    [SerializeField] bool canMove = true;

    [Header("Jumping")]
    [SerializeField] float jumpSpeed;

    //Internal Variables
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    Collider2D cldr;
    [HideInInspector] public bool isMoving, isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cldr = GetComponent<Collider2D>();
        isGrounded = cldr.IsTouchingLayers(LayerMask.GetMask("Grass", "Gravel", "Rock", "Sand", "Snow", "Wood", "Metal"));
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipSprite();
    }

    private void Update()
    {
        isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        isGrounded = cldr.IsTouchingLayers(LayerMask.GetMask("Grass", "Gravel", "Rock", "Sand", "Snow", "Wood", "Metal"));
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnMove(InputValue value) => moveInput = value.Get<Vector2>();

    private void MovePlayer()
    {
        if (canMove)
        {
            Vector2 movePlayer = new(x: moveInput.x * moveSpeed * moveMultiplier * Time.deltaTime, y: rb.velocity.y);
            rb.velocity = movePlayer;
        }

        animator.SetBool("isMoving", isMoving && isGrounded);
    }

    private void OnJump(InputValue value)
    {
        if (isGrounded && value.isPressed)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
            animator.SetTrigger("Jump");
        }
    }

    private void FlipSprite()
    {
        bool horizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (horizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }
}

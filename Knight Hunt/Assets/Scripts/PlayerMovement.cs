using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float moveMultiplier;
    public bool canMove = true;

    [Header("Jumping")]
    [SerializeField] float jumpSpeed;

    /* [Header("Climbing")]
    [SerializeField] float climbSpeed;
    [SerializeField] float climbMultiplier; */

    //Internal Variables

    //float startGravity;
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
        //startGravity = rb.gravityScale;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipSprite();
        //ClimbLadder();
        isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        isGrounded = cldr.IsTouchingLayers(LayerMask.GetMask("Grass", "Gravel", "Metal", "Wood", /*"Water", */ "Sand", "Snow", "Rock"));
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
        if (!isGrounded)
        {
            animator.SetBool("isMoving", true);
            return;
        }

        if (value.isPressed)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }

        animator.SetBool("isMoving", false);
    }

    private void FlipSprite()
    {
        bool horizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (horizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    /*void ClimbLadder()
    {
        if (!cldr.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            animator.SetBool("isClimbing", false);
            rb.gravityScale = startGravity;
            return;
        }

        rb.velocity = new Vector2(x: rb.velocity.x, y: moveInput.y * climbSpeed * climbMultiplier * Time.deltaTime);
        rb.gravityScale = 0;

        bool verticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", verticalSpeed);

    } */
}

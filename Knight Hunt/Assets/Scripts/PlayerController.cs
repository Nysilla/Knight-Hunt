using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1, jumpHeight = 1, multiplier = 10;
    private Rigidbody2D rigidbody;
    private CapsuleCollider2D collider;
    [HideInInspector] public bool isMoving, isGrounded;

    Vector2 moveInput;
    //private KeyCode sprint = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        PlayerRun();
        isGrounded = collider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        isMoving = Mathf.Abs(rigidbody.velocity.x) > 0;
    }

    private void PlayerRun()
    {
        rigidbody.velocity = new Vector2(x: playerSpeed * moveInput.x * multiplier * Time.deltaTime, y: rigidbody.velocity.y);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if(value.isPressed)
        {
            rigidbody.velocity += new Vector2(x: 0, y: jumpHeight * multiplier * Time.deltaTime);
        }
    }
    
}

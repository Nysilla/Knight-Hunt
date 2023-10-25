using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 20, jumpHeight = 20; 
    private float multiplier = 100;
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    //private KeyCode sprint = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    private void PlayerJump()
    {
        if(collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rigidbody.velocity += new Vector2(x: 0, y: Input.GetAxisRaw("Fire1") * jumpHeight * multiplier * Time.deltaTime);
        }

        
    }

    private void MovePlayer()
    {
        Vector2 movePlayer = new(x: Input.GetAxisRaw("Horizontal") * playerSpeed * multiplier * Time.deltaTime, y: rigidbody.velocity.y);

        rigidbody.velocity = movePlayer;
    }
}

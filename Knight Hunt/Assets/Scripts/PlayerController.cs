using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 20, jumpHeight = 20;
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    private KeyCode jump = KeyCode.Space, forward = KeyCode.D, backward = KeyCode.A, sprint = KeyCode.LeftShift;

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
        if(Input.GetKeyDown(jump) && collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rigidbody.velocity = new Vector2(x: 0, y: jumpHeight * 10 * Time.deltaTime);
        }

        
    }

    private void MovePlayer()
    {
        Vector2 movePlayer = new(x: playerSpeed * 10 * Time.deltaTime, y: 0);

        if (Input.GetKey(forward))
        {
            rigidbody.velocity = Input.GetKey(sprint) ? movePlayer * 2 : movePlayer;

        }
        else if (Input.GetKey(backward))
        {
            rigidbody.velocity = Input.GetKey(sprint) ? -(movePlayer * 2) : -movePlayer;

        }
    }
}

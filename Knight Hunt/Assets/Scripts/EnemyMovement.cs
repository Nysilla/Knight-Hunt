using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, chaseDistance = 1;

    //Internal Variables
    private Rigidbody2D rb;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        //rb.velocity = new Vector2(moveSpeed, 0f);

        MoveEnemy();
        FlipEnemyFacing();
    }

    private void MoveEnemy()
    {
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position - transform.position;
        bool playerIsClose = playerPosition.magnitude < chaseDistance;
        

        if (playerIsClose)
        {
            playerPosition.Normalize();
            rb.velocity = playerPosition * new Vector2(x: 100 * moveSpeed * Time.deltaTime, y: rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        
    }

    /* void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    } */

    void FlipEnemyFacing()
    {
        bool horizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (horizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);
        }
    }
}

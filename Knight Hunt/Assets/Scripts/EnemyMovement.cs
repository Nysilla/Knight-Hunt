using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, chaseDistance = 1;

    //Internal Variables
    private Rigidbody2D rb;
    private GameObject player;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        player = GameObject.FindWithTag("Player");
        //rb.velocity = new Vector2(moveSpeed, 0f);

        MoveEnemy();
        FlipEnemyFacing();
    }

    private void MoveEnemy()
    {
        Vector3 playerPosition = player.transform.position - transform.position;
        bool playerIsClose = playerPosition.magnitude < chaseDistance;
        
        if (playerIsClose)
        {
            playerPosition.Normalize();
            Vector2 moveEnemy = playerPosition * new Vector2(x: 100 * Time.deltaTime * moveSpeed, y: rb.velocity.y);
            rb.velocity = moveEnemy;
        }
        else
        {
            rb.velocity = Vector2.zero;
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

    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(transform.position, chaseDistance);
}

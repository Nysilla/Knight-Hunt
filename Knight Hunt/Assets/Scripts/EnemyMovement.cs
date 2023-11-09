using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, chaseDistance = 1;
    [SerializeField] private bool canMove = true;

    //Internal Variables
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        //player = GameObject.FindWithTag("Player");

        rb.velocity = new(0, rb.velocity.y);

        if (!canMove)
        {
            return;
        }

        MoveEnemy();
        FlipEnemyFacing();
    }

    private void MoveEnemy()
    {
        Vector3 playerPosition = player.transform.position - transform.position;
        bool playerIsClose = playerPosition.magnitude < chaseDistance;

        playerPosition.Normalize();
        Vector2 moveEnemy = new(x: 100 * Time.deltaTime * moveSpeed * playerPosition.x, y: rb.velocity.y);
        rb.velocity = playerIsClose ? moveEnemy : Vector3.zero;
    }

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

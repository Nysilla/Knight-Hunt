using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, chaseDistance = 1;

    //Internal Variables
    private Rigidbody2D rb;
    private GameObject player;
    public bool canMove = true;
    public Mathf mathF;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        //player = GameObject.FindWithTag("Player");

        if (canMove)
        {
            MoveEnemy();
            FlipEnemyFacing();
        }
        
    }

    private void MoveEnemy()
    {
        Vector3 playerPosition = player.transform.position - transform.position;
        bool playerIsClose = playerPosition.magnitude < chaseDistance;

        playerPosition.Normalize();
        Vector2 moveEnemy = playerPosition.x * new Vector2(x: 100 * Time.deltaTime * moveSpeed, y: rb.velocity.y);
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

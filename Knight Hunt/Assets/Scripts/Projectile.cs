using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;
    public float projectileLife;
    public float projectileCount;
    public PlayerMovement playerMovement;
    public bool facingright;
    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //facingright = playerMovement.playerHasHorizontalSpeed;
        facingright = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.x > Mathf.Epsilon;
        if (!facingright)
        { 
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 0, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if(!facingright ==true)
        {
            
            projectileRb.velocity = new Vector2(+speed, projectileRb.velocity.y);
        }
        else
        {
           
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;

    public float speed;
    public float projectileLife;
    public float projectileCount;

    [SerializeField] int dmg;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;

        if (projectileCount <= 1)
        {
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            projectileRb.velocity = new Vector2(+speed, projectileRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}

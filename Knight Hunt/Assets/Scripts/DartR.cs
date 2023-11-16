using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartR : MonoBehaviour
{
    public Rigidbody2D dartRB;
    public float dartSpeed;

    public float dartlife;
    public float dartCounter;

    public int dDart; //dmg

    void Start()
    {
        dartCounter = dartlife;
    }

    void Update()
    {
        if (dartCounter <= 0)
        {
            Destroy(gameObject);
        }
        dartCounter -= Time.deltaTime;

    }
    private void FixedUpdate()
    {
        dartRB.velocity = new Vector2(dartSpeed, dartRB.velocity.y);
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dDart);
        }
        Destroy (gameObject);
    }
}

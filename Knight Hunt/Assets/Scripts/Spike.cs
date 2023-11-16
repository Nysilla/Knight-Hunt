using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 13; // may be changed
    
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        { 
            playerHealth.TakeDamage(damage);
        }
    }
}

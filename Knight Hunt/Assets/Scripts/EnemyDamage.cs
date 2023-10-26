using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; 
    public int damage = 2;
    //make serilized field fdawdor dmg
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")

            playerHealth.TakeDamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}

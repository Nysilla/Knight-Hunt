using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth; 
    [SerializeField] private int damage = 1;
    [SerializeField] private float damageDelay = 1;
    private float timer;
    //make serilized field fdawdor dmg
    // Start is called before the first frame update
    void Start() => playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && timer >= damageDelay)
        {
            playerHealth.TakeDamage(damage);
            timer = 0;
        }
    }

    private void Update() => timer += Time.deltaTime;
}

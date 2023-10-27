using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float distance = 3, damageDelay = 1;
    [SerializeField] int damageAmount;
    float timer;
    [HideInInspector] public bool playerCloseToEnemy;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector3 enemyPosition = GameObject.FindWithTag("Enemy").transform.position - transform.position;
        playerCloseToEnemy = enemyPosition.magnitude < distance;

        if (playerCloseToEnemy && Input.GetKeyDown(KeyCode.Mouse0) && timer >= damageDelay)
        {
            GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            timer = 0;
        }
    }
}

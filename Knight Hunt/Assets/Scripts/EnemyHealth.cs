using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 0;
    [SerializeField] private TMPro.TextMeshProUGUI healthAndNameText;
    [SerializeField] private float distanceFromPlayer = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position - transform.position;

        bool playerIsClose = playerPosition.magnitude < distanceFromPlayer;
        healthAndNameText.enabled = playerIsClose;
        Debug.Log("Is Near: " + playerIsClose);
        healthAndNameText.text = gameObject.name + " / Health: " + currentHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

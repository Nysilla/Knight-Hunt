using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 0;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayEnemyHealth();
    }

    private void DisplayEnemyHealth()
    {
        string enemyNameAndHealth = $"Health: {currentHealth}";

        if (currentHealth < 100)
        {
            healthText.enabled = true;
        }
        healthText.text = enemyNameAndHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            healthText.enabled = false;
            Destroy(gameObject);
        }
    }
}

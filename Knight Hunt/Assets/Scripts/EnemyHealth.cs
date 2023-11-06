using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 0;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    private Vector3 textScale;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.enabled = false;
        textScale = healthText.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayEnemyHealth();
    }

    private void DisplayEnemyHealth()
    {
        Vector3 enemyFacing = gameObject.transform.localScale.x < 0 ? new(-textScale.x, textScale.y, textScale.z) : textScale;
        healthText.transform.localScale = enemyFacing;
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

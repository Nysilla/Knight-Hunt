using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    [SerializeField] private float healDelay;
    [SerializeField] private TextMeshProUGUI healthText;
    private float healTimer;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = "Health: " + health;
    }

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            healthText.text = "Health: " + health;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (health < maxHealth)
        {
            health += amount;
            healthText.text = "Health: " + health;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
            healthText.text = "Health: " + health;
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() 
    {
        //test
        if (Input.GetKeyDown(KeyCode.Q) && healTimer != healDelay)
        {
            Heal(10);
        }
    }
}

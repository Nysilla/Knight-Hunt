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
    [SerializeField] private AudioClip healSFX;
    private AudioSource audioSource;
    private float healTimer;

    //test
    [Header("Test")]
    [SerializeField] private float damageDelay = 1; 
    [SerializeField] private bool shouldDamagePlayer;

    private float timer;
    //

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = "Health: " + health;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int health)
    {
        if (this.health > 0)
        {
            this.health -= health;
            healthText.text = "Health: " + this.health;
        }

        if (this.health <= 0)
        {
            SetHealth(0);

            /*alternative
            gameObject.SetActive(false);
            */

            PlayerDied();
        }
    }

    public void Heal(int health)
    {
        if (this.health < maxHealth)
        {
            audioSource.PlayOneShot(healSFX);
            this.health += health;
            healthText.text = "Health: " + this.health;
        }

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
            healthText.text = "Health: " + this.health;
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
        healthText.text = "Health: " + this.health;
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
        timer += Time.deltaTime;

        if (shouldDamagePlayer && timer >= damageDelay)
        {
            TakeDamage(15);
            timer = 0;
        }
        //

        healTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && healTimer >= healDelay)
        {
            Heal(10);
            healTimer = 0;
        }
    }
}

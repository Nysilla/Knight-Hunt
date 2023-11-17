using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    [SerializeField] private float healDelay;
    [SerializeField] private TextMeshProUGUI healthText, healPotionsText;
    [SerializeField] private AudioClip healSFX, healPickupSFX;

    //Internal Variables
    [HideInInspector] public int healPotions;
    [SerializeField] private int startingPotions = 3;
    private AudioSource audioSource;
    private float healTimer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = $"Health: {health}";
        healPotionsText.text = $"= {healPotions}";
        audioSource = GetComponent<AudioSource>();
        healPotions = startingPotions;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int health)
    {
        if (this.health > 0)
        {
            this.health -= health;
        }
    }

    public void Heal(int health)
    {
        if (this.health < maxHealth)
        {
            this.health += health;
            healPotions--;
            audioSource.PlayOneShot(healSFX);
        }

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && healTimer >= healDelay && healPotions > 0)
        {
            Heal(10);
            healTimer = 0;
        }

        if (health <= 0)
        {
            Die();
            Invoke(nameof(ReloadScene), 2);
        }

        healthText.text = $"Health: {health}";
        healPotionsText.text = $"= {healPotions}";
    }

    private void Die()
    {
        SetHealth(0);
        animator.SetTrigger("Die");
        GetComponent<PlayerMovement>().canMove = false;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Health Potion"))
        {
            healPotions++;
            audioSource.PlayOneShot(healPickupSFX);
            Destroy(collision.gameObject);
        }
    }
}

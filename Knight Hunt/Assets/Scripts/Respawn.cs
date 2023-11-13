using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    /* [SerializeField] private bool respawnPlayer;
    [SerializeField] private int damageAmount; */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !respawnPlayer)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    } */
}

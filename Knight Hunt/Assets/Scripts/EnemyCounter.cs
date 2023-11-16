using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    private GameObject[] enemies;
    private bool canEnter;
    [SerializeField] private TMPro.TextMeshProUGUI enemyCounter;

    // Update is called once per frame
    void Update()
    {
        CountEnemies();
    }

    private void CountEnemies()
    {
        GameObject.Find("Finish Line").GetComponent<LoadLevelOnTrigger>().allowedIn = canEnter;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCounter.text = $"Remaining Enemies: {enemies.Length}";

        bool noEnemiesLeft = enemies.Length == 0;
        canEnter = noEnemiesLeft;

        if (noEnemiesLeft)
        {
            Debug.Log("Finish!");
        }
    }
}

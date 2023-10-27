using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyName : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI enemyText;

    // Update is called once per frame
    void Update()
    {
        enemyText.enabled = GetComponent<PlayerDamage>().playerCloseToEnemy && GameObject.FindWithTag("Enemy");

    }
}

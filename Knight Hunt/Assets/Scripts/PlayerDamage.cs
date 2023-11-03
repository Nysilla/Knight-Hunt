using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float attackDistance = 0.5f, damageDelay = 1;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private AudioClip[] damageSFX;
    //[SerializeField] private float audioLength = 1;

    //Internal Variables
    private AudioSource audioSource;
    private float timer;
    private GameObject enemy;
    [HideInInspector] public bool isAttacking;

    public int Song { get; set; } = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        isAttacking = Input.GetKeyDown(KeyCode.Mouse0) && timer >= damageDelay;

        if (isAttacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackDistance, LayerMask.GetMask("Enemy"));

        foreach(Collider2D enemy in enemies)
        {
            this.enemy = enemy.gameObject;
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);
            PlaySFX(damageSFX);
            Debug.Log(enemy);
        }

        timer = 0;
    }

    private void PlaySFX(AudioClip[] audioClips)
    {
        if (Song != audioClips.Length)
        {
            PlayNextSFX(audioClips);
        }
    }

    private void PlayNextSFX(AudioClip[] audios)
    {
        if (Song < audios.Length - 1)
        {
            Song++;
        }
        else
        {
            Song = 0;
        }
        audioSource.PlayOneShot(audios[Song]);
        //SongLength = 0;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackDistance);
    }
}

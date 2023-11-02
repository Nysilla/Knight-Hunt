using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float distance = 3, damageDelay = 1;
    [SerializeField] int damageAmount;

    [Header("SFX")]
    [SerializeField] private AudioClip[] damageSFX;
    [SerializeField] private AudioClip[] attackSFX;
    //[SerializeField] private float audioLength = 1;

    //Internal Variables
    private BoxCollider2D frontOfPlayer;
    private AudioSource audioSource;
    float timer;
    //[HideInInspector] public bool playerCloseToEnemy;

    public int Song { get; set; } = 0;
    //public float SongLength { get; set; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        frontOfPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        bool isAttacking = Input.GetKeyDown(KeyCode.Mouse0) && timer >= damageDelay;

        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (!enemy)
        {
            return;
        }

        Vector3 enemyPosition = enemy.transform.position - transform.position;

        if (isAttacking)
        {
            bool closeToEnemy = enemyPosition.magnitude < distance;

            if (closeToEnemy && frontOfPlayer.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
                PlaySFX(damageSFX);
            }
            PlaySFX(attackSFX);
            timer = 0;
        }
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
}

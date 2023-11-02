using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] float distance = 3, damageDelay = 1;
    [SerializeField] int damageAmount;
    [SerializeField] private AudioClip[] damageSFX;
    //[SerializeField] private float audioLength = 1;

    //Internal Variables
    private BoxCollider2D frontOfPlayer;
    private GameObject enemy;
    private AudioSource audioSource;
    private CapsuleCollider2D capsule;
    [HideInInspector] public bool isAttacking; 
    float timer;
    //[HideInInspector] public bool playerCloseToEnemy;

    public int Song { get; set; } = 0;
    //public float SongLength { get; set; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        frontOfPlayer = GetComponent<BoxCollider2D>();
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        capsule = GetComponent<CapsuleCollider2D>();
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        isAttacking = Input.GetKeyDown(KeyCode.Mouse0) && timer >= damageDelay;

        if (!enemy)
        {
            return;
        }

        Vector3 enemyPosition = enemy.transform.position - transform.position;

        if (isAttacking)
        {
            //bool closeToEnemy = enemyPosition.magnitude < distance;

            bool playerFacingEnemy = frontOfPlayer.IsTouchingLayers(LayerMask.GetMask("Enemy"));

            if (/*closeToEnemy && */ playerFacingEnemy)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
                PlaySFX(damageSFX);
                timer = 0;
            }
        }
    }

    public void PlaySFX(AudioClip[] audioClips)
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

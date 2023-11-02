using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAttackSFX : MonoBehaviour
{

    [SerializeField] private AudioClip[] attackSFX;
    private PlayerDamage playerDamage;
    private AudioSource audioSource;
    float timer;
    public int Song { get; set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GetComponent<PlayerDamage>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDamage.isAttacking)
        {
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

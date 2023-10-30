using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSFX : MonoBehaviour
{
    [SerializeField] AudioClip[] grass, gravel, metal, wood, sand, snow, rock /*, water*/ ;
    [SerializeField] float audioLength = 1;
    private AudioSource audio;
    private PlayerMovement player;
    Collider2D collider;

    public int Song { get; set; } = 0;
    public float SongLength { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SongLength += Time.deltaTime;

        if(!player.isGrounded)
        {
            return;
        }

        if (player.isMoving && SongLength >= DetermineSFX()[Song].length * (1 / audioLength) && Song != DetermineSFX().Length)
        {
            PlayNextSFX(DetermineSFX());
        }
    }

    private AudioClip[] DetermineSFX()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Grass")))
        {
            return grass;
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Gravel")))
        {
            return gravel;
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Metal")))
        {
            return metal;
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Wood")))
        {
            return wood;
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Sand")))
        {
            return sand;
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Snow")))
        {
            return snow;
        }
        /* else if (collider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            return water;
        } */
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Rock")))
        {
            return rock;
        }
        else
        {
            return null;
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
        audio.PlayOneShot(audios[Song]);
        SongLength = 0;
    }
}

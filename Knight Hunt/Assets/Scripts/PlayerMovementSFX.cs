using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSFX : MonoBehaviour
{
    [SerializeField] AudioClip[] grass, gravel, metal, wood, tile, sand, snow, rock, water;
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

        if (player.isMoving 
            && SongLength >= grass[Song].length * 0.5
            && Song != grass.Length)
        {
            DetermineSFX();

        }
    }

    private void DetermineSFX()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Grass")))
        {
            PlayNextSFX(grass);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Gravel")))
        {
            PlayNextSFX(gravel);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Metal")))
        {
            PlayNextSFX(metal);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Wood")))
        {
            PlayNextSFX(wood);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Tile")))
        {
            PlayNextSFX(tile);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Sand")))
        {
            PlayNextSFX(sand);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Snow")))
        {
            PlayNextSFX(snow);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            PlayNextSFX(water);
        }
        else if (collider.IsTouchingLayers(LayerMask.GetMask("Rock")))
        {
            PlayNextSFX(rock);
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

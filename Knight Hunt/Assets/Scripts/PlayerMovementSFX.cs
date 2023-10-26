using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSFX : MonoBehaviour
{
    [SerializeField] AudioClip[] movementSFX;
    private AudioSource audio;
    private PlayerMovement player;

    public int Song { get; set; } = 0;
    public float SongLength { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement>();
        audio.PlayOneShot(movementSFX[Song]);
    }

    // Update is called once per frame
    void Update()
    {
        SongLength += Time.deltaTime;

        if (player.isGrounded
            && ((player.isMoving && SongLength >= movementSFX[Song].length) 
            /* || (player.isSprinting && SongLength >= movementSFX[Song].length * 0.5f) */ )
            && Song != movementSFX.Length)
        {
            PlayNextSFX(movementSFX);
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

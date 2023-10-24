using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public void LoadAScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void PlaySFX(AudioClip audioClip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audioClip);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting.");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadAScene(int scene)
    {
        SceneManager.LoadScene(scene);
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

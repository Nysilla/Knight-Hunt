using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelOnTrigger : MonoBehaviour
{
    [SerializeField] private int scene;
    public bool allowedIn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (allowedIn)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}

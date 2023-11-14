using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private GameObject controlsText;
    private int clickedQ;

    private void Start()
    {
        controlsText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (clickedQ == 0)
            {
                Time.timeScale = 0;
                clickedQ++;
                controlsText.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                clickedQ--;
                controlsText.SetActive(false);
            }
        }
    }
}

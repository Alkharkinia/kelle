using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();

            }

        }



    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameMenuUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameMenuUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}

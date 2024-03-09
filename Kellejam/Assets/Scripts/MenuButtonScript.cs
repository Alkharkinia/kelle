using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public void GoToMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadSceneAsync(0);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }
}

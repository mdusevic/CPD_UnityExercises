using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GotoLevel1Scene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void GotoLevel2Scene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void GotoExit()
    {
        Application.Quit();
    }
}

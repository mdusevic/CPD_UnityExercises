using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void GotoExit()
    {
        Application.Quit();
    }
}

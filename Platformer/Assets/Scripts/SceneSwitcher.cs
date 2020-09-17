using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnStartUp()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void GotoLevelSelect()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Level Select Menu", LoadSceneMode.Single);
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

    public void GotoLevel3Scene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void GotoExit()
    {
        Application.Quit();
    }
}

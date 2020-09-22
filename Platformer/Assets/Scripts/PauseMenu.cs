using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseIcon;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        pauseIcon.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameIsPaused = !GameIsPaused;
        }

        if (pauseMenuUI.activeSelf)
        {
            GameIsPaused = true;
        }

        else if (!pauseMenuUI.activeSelf)
        {
            GameIsPaused = false;
        }

        if (GameIsPaused)
        {
            Pause();
        }

        else if (!GameIsPaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

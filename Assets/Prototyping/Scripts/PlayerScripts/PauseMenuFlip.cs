using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuFlip : MonoBehaviour
{
    //variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsUI;

    //resume function
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GetComponent<PlayerControllerFlip>().enabled = true;
    }

    //pause function
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GetComponent<PlayerControllerFlip>().enabled = false;
    }

    //enables settings
    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    //loads to main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
    }

    //send user to SparkleGem's basement
    public void QuitGame()
    {
        Application.Quit();
    }

    //input system pause function
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //input system resume function
    public void Resume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Resume();
            GetComponent<PlayerController>().enabled = true;
        }
    }
}

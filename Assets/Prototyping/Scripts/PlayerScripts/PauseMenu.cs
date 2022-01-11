using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsUI;

	// Update is called once per frame
	void Update () 
    {
		/*if (Input.GetButtonDown("Submit"))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (Input.GetButtonDown("Punch") && GameIsPaused)
        {
            Resume();
            GetComponent<PlayerController>().enabled = true;
        }*/
	}

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GetComponent<PlayerController>().enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GetComponent<PlayerController>().enabled = false;
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        GameIsPaused = false;
    }

    //send user to the shadow realm
    public void QuitGame()
    {
        Application.Quit();
    }

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

    public void Resume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Resume();
            GetComponent<PlayerController>().enabled = true;
        }
    }
}

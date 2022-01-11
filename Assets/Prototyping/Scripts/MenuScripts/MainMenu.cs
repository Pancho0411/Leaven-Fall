using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour {

    //starts game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //loads credits scene
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    //loads title screen scene
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //send user to SparkleGem's basement
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //loads settings scene
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");

    }

    //input system back function
    public void back(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

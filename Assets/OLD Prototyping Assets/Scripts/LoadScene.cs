using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LoadScene : MonoBehaviour
{
    public void LoadMenuSettings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*void Update()
    {
        if (Input.GetButtonDown("Punch"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }*/

    public void back(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

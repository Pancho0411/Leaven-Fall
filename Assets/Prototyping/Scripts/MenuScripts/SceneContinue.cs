using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneContinue : MonoBehaviour
{
    public string levelToLoad;

    public void start(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void loadTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{

    public string levelToLoad;

    public void newGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

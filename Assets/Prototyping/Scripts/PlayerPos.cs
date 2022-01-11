using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerPos : MonoBehaviour
{
    private CheckpointMaster CM;

    void Start()
    {
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
        transform.position = CM.lastCheckPointPos;
    }

    public void Respawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public int gems;
    public int lives;

    //attach to collider to autosave data at end of level
    public void SavePlayer(PlayerController player)
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        gems = data.gems;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}

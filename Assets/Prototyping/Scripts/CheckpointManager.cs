using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private CheckpointMaster CM;

    void Start()
    {
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CM.lastCheckPointPos = transform.position;
            Destroy(this);
        }
    }


}

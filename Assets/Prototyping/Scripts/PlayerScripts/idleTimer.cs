using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleTimer : MonoBehaviour
{
    public float targetTime = 10.0f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        targetTime -= Time.deltaTime;

        if(targetTime <= 0.0f && targetTime >= -2.0f)
        {
            anim.SetBool("Idling", true);
        }

        if(targetTime <= -2.5f)
        {
            anim.SetBool("Idling", false);
        }

        //Do these to interupt Idle animations and go to other animation states
        if (anim.GetInteger("state") == 1)
        {
            targetTime = 10.0f;
            anim.SetBool("Idling", false);

        }

        if (anim.GetInteger("state") == 2)
        {
            targetTime = 10.0f;
            anim.SetBool("Idling", false);

        }
    }
}

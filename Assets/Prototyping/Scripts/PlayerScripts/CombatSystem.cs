using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatSystem : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Animator anim;

    [SerializeField] private int noOfPresses = 0;

    private float lastPressedTime = 0;

    [SerializeField] private float cooldownTime;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Time.time - lastPressedTime > cooldownTime)
        {
            noOfPresses = 0;
        }

        //punch();
    }

    public void return1()
    {
        if(noOfPresses >= 2)
        {
            anim.SetBool("Attack2", true);
        }
        else
        {
            anim.SetBool("Attack1", false);
            noOfPresses = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }

    public void return2()
    {
        if(noOfPresses >= 3)
        {
            anim.SetBool("Attack3", true);
        }
        else
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack1", false);
            noOfPresses = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }

    public void return3()
    {
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        noOfPresses = 0;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    /*public void punch()
    {
        if (Input.GetButtonDown("Punch"))
        {
            lastPressedTime = Time.time;
            noOfPresses++;
            if (noOfPresses == 1)
            {
                anim.SetBool("Attack1", true);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            noOfPresses = Mathf.Clamp(noOfPresses, 0, 3);
        }
    }*/

    public void Punch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lastPressedTime = Time.time;
            noOfPresses++;
            if (noOfPresses == 1)
            {
                anim.SetBool("Attack1", true);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            noOfPresses = Mathf.Clamp(noOfPresses, 0, 3);
        }
    }
}

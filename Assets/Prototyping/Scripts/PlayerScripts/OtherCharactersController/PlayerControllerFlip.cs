using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class PlayerControllerFlip : MonoBehaviour
{
    //variables
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, jumping, running, falling}
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float ogSpeed = 10f;
    [SerializeField] private float boostSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    public int gems = 0;
    [SerializeField] private TMP_Text GemCounter;
    public int lives = 3;
    [SerializeField] private TMP_Text LifeCounter;
    [SerializeField] Slider HP;
    [SerializeField] Slider EP;
    [SerializeField] private GameObject Character;
    private float inputX;
    public bool boostPress;

    //get components
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        LifeCounter.text = lives.ToString();
        EP.value = 100;
        ogSpeed = speed;
    }

    //call functions
    private void Update()
    {
        Movement();

        AnimationState();

        anim.SetInteger("state", (int)state);

        boostAction();

    }

    //item detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //increment gem counter if gem is coollected
        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            gems += 1;
            GemCounter.text = gems.ToString();
        }

        //increment lives when 1up is collected
        if (collision.tag == "1UP")
        {
            Destroy(collision.gameObject);
            lives += 1;
            LifeCounter.text = lives.ToString();
        }

        //add to pop gauge when pop is collected
        if(collision.tag == "pOp")
        {
            Destroy(collision.gameObject);
            EP.value += 10;
        }
    }

    //movement function
    public void Movement()
    {
        //set horizontal direction to x input
        float Hdirection = inputX;

        //if hdirection is less than 0 go left
        if (Hdirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            anim.SetInteger("Velocity", -1);
        }

        //if hdirection is greater than 0 go right
        else if (Hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            anim.SetInteger("Velocity", 1);
        }

        //if hdirection is 0 stay idle and don't move
        else if (Hdirection == 0)
        {
            anim.SetInteger("Velocity", 0);
        }
    }

    //state machine
    private void AnimationState()
    {
        //determine if jumping, if true is falling
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
            
        }

        //determine if falling is true, are you runnning or idle when you hit the ground
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground) && Mathf.Abs(rb.velocity.x) == 0)
            {
                state = State.idle;
            }
            else if (coll.IsTouchingLayers(ground) && ((Mathf.Abs(rb.velocity.x) > 1) || (Mathf.Abs(rb.velocity.x) < -1)))
            {
                state = State.running;
            }
        }

        //determine if running, else you are idle
        else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    }

    //boost action for Leo          MOVE ONCE ALL ACTIONS ARE WRITTEN TO ACTION SCRIPT
    public void boostAction()
    {
        
         
            if ((anim.GetInteger("Velocity") == 1) && boostPress == true)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                EP.value -= 0.25f;
            }
            if ((anim.GetInteger("Velocity") == -1) && boostPress == true)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                EP.value -= 0.25f;
            }
            if ((anim.GetInteger("Velocity") == 0) && boostPress == true)
            {
                return;  
            }
            if (EP.value <= 0)
            {
                speed = ogSpeed;
                boostPress = false;
            }
        
    }

    //input system move function
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    //input system jump function
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    //input system boost function       MOVE ONCE ALL ACTIONS ARE WRITTEN TO ACTION SCRIPT
    public void Boost(InputAction.CallbackContext context)
    {
        if(EP.value > 0)
        {
            if (context.performed)
            {
                if (Character = GameObject.Find("Leo"))
                {
                    speed = boostSpeed;
                    boostPress = true;
                }
            }
            else
            {
                speed = ogSpeed;
                boostPress = false;
            }
        }
        else
        {
            speed = ogSpeed;
            boostPress = false;
        }

    }
}
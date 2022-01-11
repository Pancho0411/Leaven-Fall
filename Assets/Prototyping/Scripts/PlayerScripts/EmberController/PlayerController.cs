using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    private enum State {idle, jumping, running, falling, hurt, die}

    private State state = State.idle;

    private Collider2D coll;

    [SerializeField] private LayerMask ground;

    [SerializeField] private float speed = 10f;

    [SerializeField] private float jumpForce = 10f;

    public int gems = 0;

    [SerializeField] private TMP_Text GemCounter;

    public int lives = 3;

    [SerializeField] private TMP_Text LifeCounter;

    [SerializeField] Slider HP;

    [SerializeField] Slider EP;

    private float inputX;

    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        LifeCounter.text = lives.ToString();
    }

    private void Update()
    {
        Movement();

        AnimationState();

        anim.SetInteger("state", (int)state);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            gems += 1;
            GemCounter.text = gems.ToString();
        }

        if (collision.tag == "1UP")
        {
            Destroy(collision.gameObject);
            lives += 1;
            LifeCounter.text = lives.ToString();
        }

        if (collision.tag == "pOp")
        {
            Destroy(collision.gameObject);
            HP.value += 100;
        }

        if (collision.tag == "lvl1Enemy")
        {
            state = State.hurt;
            HP.value -= 5;
        }
    }

    public void Movement()
    {
        float Hdirection = inputX;

        if (Hdirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetInteger("Velocity", -1);
        }

        else if (Hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetInteger("Velocity", 1);
        }

        else if (Hdirection == 0)
        {
            anim.SetInteger("Velocity", 0);
        }

        if (rb.velocity.y < -0.1f)
        {
            state = State.falling;
        }
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
            
        }

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

        else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon || Mathf.Abs(rb.velocity.x) < -Mathf.Epsilon)
        {
            state = State.running;
        }

        else if (HP.value == 0f)
        {
            state = State.die;
        }

        else if(coll.tag == "lvl1Enemy")
        {
            state = State.hurt;
            
        }

        else
        {
            state = State.idle;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MGround"))
        {
            this.transform.parent = other.transform;
            state = State.idle;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("MGround"))
        {
            this.transform.parent = null;
            state = State.falling;
        }
    }

    public void lifeManager()
    {
        if(lives < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

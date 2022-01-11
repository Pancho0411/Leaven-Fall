using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    public Rigidbody2D myRigidbody { get; set; }

    public bool Slide { get; set; }

    public bool Jump { get; set; }

    public bool OnGround { get; set; }

    private Vector2 startPos;
  
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        startPos = transform.position;

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (transform.position.y <= -14f)
        {
            myRigidbody.velocity = Vector2.zero;
            transform.position = startPos;
        }
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log("Horizontal");

        OnGround = IsGrounded();

        HandleMovement(horizontal);

        Flip(horizontal);

        HandleLayers();

    }

    private void HandleMovement(float horizontal)
    {
        if (myRigidbody.velocity.y < 0)
        {
            MyAnimator.SetBool("land", true);
        }

        if (!Attack && !Slide && (OnGround || airControl))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }

        if (Jump && myRigidbody.velocity.y == 0)
        {
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }

        MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            MyAnimator.SetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            MyAnimator.SetTrigger("slide");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyAnimator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MyAnimator.SetTrigger("throw");
            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            MyAnimator.SetTrigger("movingThrow");
            
        }

    }

    private void Flip(float horizontal)
    {
        if (this.MyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            return;
        }

        if (this.MyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            return;
        }

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
        }
    }

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i= 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void HandleLayers()
    {
        if (!OnGround)
        {
            MyAnimator.SetLayerWeight(1, 1);
        }

        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }

    public override void Projectile(int value)
    {
        if (!OnGround && value == 1 || OnGround && value == 0)
        {
            base.Projectile(value);
        }
    }

}

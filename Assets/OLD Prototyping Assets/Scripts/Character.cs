using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Animator MyAnimator { get; private set; }

    [SerializeField]
    protected Transform ProjectilePos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    protected GameObject projectilePrefab;

    public bool Attack { get; set; }

    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    public virtual void Projectile(int value)
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(projectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Projectile>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(projectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Projectile>().Initialize(Vector2.left);
        }
    }
}

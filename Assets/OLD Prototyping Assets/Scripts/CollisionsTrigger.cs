using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsTrigger : MonoBehaviour
{
    private BoxCollider2D playerCollider;

    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

    [SerializeField] private BoxCollider2D Player;

    void Start()
    {
        playerCollider = Player;
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerCollider)
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (playerCollider)
        {
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
    }
}

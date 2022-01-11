using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotate : MonoBehaviour
{
    public GameObject player;

    private Collider2D coll;

    [SerializeField] private LayerMask ground;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.transform.rotation = other.gameObject.transform.rotation;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.transform.parent = null;
        }
    }

    //public void Rotate()
    //{
    //    if (coll.IsTouchingLayers(ground))
    //    {
    //        player.transform.rotation = gameObject.transform.rotation;
    //    }
    //}
    
}

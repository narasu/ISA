using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2D : MonoBehaviour
{
    public bool onGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            onGround = false;
        }
    }
}

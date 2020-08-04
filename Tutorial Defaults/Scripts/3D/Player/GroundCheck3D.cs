using UnityEngine;
using System.Collections;

public class GroundCheck3D : MonoBehaviour
{
    private static GroundCheck3D instance;
    public static GroundCheck3D Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GroundCheck3D>();

            return instance;
        }
    }
    internal bool onGround = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.tag == "Ground" && Player3D.Instance.controller.velocity.y<=0)
        {
            Debug.Log(Player3D.Instance.controller.velocity.y);
            onGround = true;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground" && onGround == true)
        {
            onGround = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    private static Player2D instance;
    public static Player2D Instance
    {
        get
        {
            return instance;
        }
    }

    public GroundCheck2D groundCheck;
    public float jumpForce = 5.0f;
    public float walkSpeed = 2.0f;
    private Rigidbody2D rigidBody;
    private BoxCollider2D col;
    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.onGround)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Move();
    }

    private void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal") * walkSpeed;
        /*
        if (movement == 0)
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            return;
        }
        */
        Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = new Vector2(Mathf.Sign(movement), 0);
        float hitLength = sr.bounds.extents.x + 0.01f;
        //Debug.Log(hitLength);

        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, hitLength, mask);

        //Vector2 size = new Vector2(0.1f, sr.bounds.size.y - 0.01f);
        //RaycastHit2D hit = Physics2D.BoxCast(transform.position, size, 0, direction, hitLength, mask);
        



        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(transform.position.x + movement, transform.position.y), movement + (sr.bounds.size.x / 2 * Mathf.Sign(movement)));
        
        if (hit)
        {
            //Debug.Log("Hit");
            movement = 0;
        }

        rigidBody.velocity = new Vector2(movement, rigidBody.velocity.y);
    }
}

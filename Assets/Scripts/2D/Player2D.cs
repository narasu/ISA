using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    
    public string inputAxis = "Vertical";
    public float moveSpeed = 5.0f;
    public float fireRate = 0.5f;
    private bool firing;
    public GameObject bullet;
    public Transform firePoint;

    public int health = 5;

    

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    private void Update()
    {
        float movement = Input.GetAxisRaw(inputAxis) * moveSpeed;
        

        if (inputAxis=="Vertical")
        {
            rb.velocity = new Vector2(0, movement);
            if (movement < 0)
                transform.localScale = new Vector3(1, -1);
            if (movement > 0)
                transform.localScale = Vector3.one;
        }
        if (inputAxis == "Horizontal")
        {
            rb.velocity = new Vector2(movement,0);
            if (movement < 0)
                transform.rotation = Quaternion.Euler(0, 0, 90);
            if (movement > 0)
                transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !firing && inputAxis == "Vertical")
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = firePoint.position;
            b.GetComponent<Bullet>().speed *= transform.localScale.y;
            
            firing = true;
            StartCoroutine(HandleFireRate());
        }

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        UIManager.Instance.healthText.text = "Health: " + health;
        //transform.Translate(Vector3.up * movement * Time.deltaTime);
    }

    public void SwitchAxis()
    {
        inputAxis = "Horizontal";
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private IEnumerator HandleFireRate()
    {
        yield return new WaitForSeconds(fireRate);
        firing = false;
    }

    public void TakeDamage()
    {
        health--;
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8.0f;
    public int damage = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(0, speed);
        AudioManager2D.Instance.PlaySound(Sound.Bullet, transform, rb);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Enemy>()?.TakeDamage(damage);
        AudioManager2D.Instance.PlaySound(Sound.EnemyHit,collision.transform);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet Destroy")
            Destroy(gameObject);
    }
}

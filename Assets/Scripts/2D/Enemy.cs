using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public float moveSpeed = 3.0f;
    Vector3 direction;

    private void Update()
    {
        direction = (Player2D.Instance.transform.position - transform.position).normalized;
        transform.Translate(moveSpeed * direction * Time.deltaTime);

        if (health <= 0)
            Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player2D.Instance.TakeDamage();
            AudioManager2D.Instance.PlaySound(Sound.PlayerHit, collision.transform);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.StartSpawn();
            Destroy(gameObject);
        }
        
    }
}

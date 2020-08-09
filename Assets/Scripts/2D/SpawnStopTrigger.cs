using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStopTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.StopSpawn();
            AudioManager2D.Instance.StopFadeOut(Sound.Noise, 1.0f);
            Destroy(gameObject);
        }

    }
}

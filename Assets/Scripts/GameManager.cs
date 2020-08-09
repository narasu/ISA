using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Above, Below }
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject enemy;
    
    public float spawnDistance = 6.5f;
    public IEnumerator spawnCoroutine;

    private void Awake()
    {
        instance = this;
        //StartCoroutine(SpawnCycle());
        spawnCoroutine = SpawnCycle();
    }

    public void StartSpawn()
    {
        StartCoroutine(spawnCoroutine);
    }

    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
    }

    public IEnumerator SpawnCycle()
    {
        while(true)
        {
            SpawnEnemy(Direction.Above);
            yield return new WaitForSeconds(1.5f);

            SpawnEnemy(Direction.Above);
            yield return new WaitForSeconds(0.4f);

            SpawnEnemy(Direction.Below);
            yield return new WaitForSeconds(1.0f);

            SpawnEnemy(Direction.Above);
            yield return new WaitForSeconds(0.5f);

            SpawnEnemy(Direction.Below);
            yield return new WaitForSeconds(0.9f);

            SpawnEnemy(Direction.Below);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void SpawnEnemy(Direction dir)
    {
        if (dir == Direction.Above)
        {
            GameObject e = Instantiate(enemy);
            e.transform.position = Player2D.Instance.transform.position + Vector3.up * spawnDistance;
            return;
        }
        if (dir == Direction.Below)
        {
            GameObject e = Instantiate(enemy);
            e.transform.position = Player2D.Instance.transform.position + Vector3.down * spawnDistance;
            e.GetComponent<Enemy>().moveSpeed += 1.5f;
        }
    }    
}

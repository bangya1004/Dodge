using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;
    [SerializeField]
    private GameObject enemyPrefab;

    void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(enemyPrefab, spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);
        }
        yield return new WaitForSeconds(3.0f);
    }
}

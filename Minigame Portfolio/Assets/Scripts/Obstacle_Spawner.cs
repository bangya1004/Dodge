using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab;
    [SerializeField]
    private GameObject[] spines;

    [SerializeField]
    private float spawnRate = 0;
    [SerializeField]
    private float minRate = 0;
    [SerializeField]
    private float maxRate = 0;

    [SerializeField]
    private float spawnMinXPos = 0;
    [SerializeField]
    private float spawnMaxXPos = 0;

    private void OnEnable()
    {
        for (int i = 0; i < spines.Length; i++)
        {
            if (Random.Range(0, 3) == 0) spines[i].SetActive(true);
            else spines[i].SetActive(false);
        }
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage_Avoid")
        {
            StartCoroutine(spwanSpike());
        }
    }

    IEnumerator spwanSpike()
    {
        while (true)
        {
            float x = Random.Range(spawnMinXPos, spawnMaxXPos);        
            Instantiate(spikePrefab, new Vector3(x, 5, 0), Quaternion.identity);
            spawnRate = Random.Range(minRate, maxRate);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

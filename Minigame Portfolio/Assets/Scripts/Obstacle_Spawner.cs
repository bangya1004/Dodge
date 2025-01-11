using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab;

    private void Awake()
    {
        StartCoroutine(spwanSpike());
    }

    private void Update()
    {

    }

    IEnumerator spwanSpike()
    {
        Instantiate(spikePrefab, transform.position, Quaternion.identity);

        yield return null;
    }
}

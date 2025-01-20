using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformObj;
    [SerializeField]
    private GameObject[] Spines;
    [SerializeField]
    private GameObject[] Saws;

    private float time;
    private float meter;

    private void Awake()
    {

    }

    private void Update()
    {
        time += Time.deltaTime;
        meter = (int)(time % 60);

        if (10 <= meter && meter < 60)
        {
            platformObj[0].SetActive(false);
            platformObj[1].SetActive(true);
        }
        else if (60 <= meter && meter < 120)
        {
            platformObj[1].SetActive(false);
            platformObj[2].SetActive(true);
        }
    }
}

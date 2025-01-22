using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private float time;
    public int meter;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        meter = (int)(time % 60);
        scoreText.text = $"{meter}m";
    }
}

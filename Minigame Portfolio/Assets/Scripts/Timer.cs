using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float time;

    private int minute;
    private int second;

    private void Awake()
    {
        StartCoroutine(StartTimer());
    }

    public IEnumerator StartTimer()
    {
        while (true)
        {
            time += Time.deltaTime;
            minute = (int)time / 60;
            second = (int)time % 60;
            timerText.text = minute.ToString("00") + ":" + second.ToString("00");      
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lifeCount = 0; 

    [SerializeField]
    private GameObject[] lifeImg;
    [SerializeField]
    private GameObject panel_GameOver;
    [SerializeField]
    private PlayerMovement player;
    [SerializeField]
    private TextMeshProUGUI bestTimerText;
    [SerializeField]
    private TextMeshProUGUI nowTimerText;

    [SerializeField]
    private Timer timer;
    [SerializeField]
    private MeterScore meter;


    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage_Avoid")
        {
            if (PlayerPrefs.HasKey("Minute"))
            {
                int pastMinute = PlayerPrefs.GetInt("Minute");
                int pastSecond = PlayerPrefs.GetInt("Second");
                bestTimerText.text = $"{pastMinute} : {pastSecond}";
            }
            else
            {
                bestTimerText.text = "0 : 00";
            }
        }
        if (SceneManager.GetActiveScene().name == "Stage_02")
        {
            if (PlayerPrefs.HasKey("Meter"))
            {
                int pastMeter = PlayerPrefs.GetInt("Meter");
                bestTimerText.text = $"{pastMeter}m";
            }
            else
            {
                bestTimerText.text = "0m";
            }
        }


    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage_Avoid")
        {
            playerDie();
        }
        //playerCollider();
    }

    public void playerDie()
    {
        int minute = timer.minute;
        int second = timer.second;
        if (lifeCount >= 3)
        {
            //Destroy(gameObject);
            player.Die();
            lifeCount = 0;
            panel_GameOver.SetActive(true);
            Time.timeScale = 0;
            nowTimerText.text = timer.timerText.text;
            if (minute > PlayerPrefs.GetInt("Minute"))
            {
                PlayerPrefs.SetInt("Minute", minute);
                PlayerPrefs.SetInt("Second", second);
            }
            if (minute == PlayerPrefs.GetInt("Minute") &&
                second > PlayerPrefs.GetInt("Second"))
            {
                PlayerPrefs.SetInt("Second", second);
            }
            bestTimerText.text = $"{PlayerPrefs.GetInt("Minute")} : {PlayerPrefs.GetInt("Second")}";
            timer.StopCoroutine("StartTimer");
            
            // 게임 오버 처리
        }
    }

    public void playerCollider()
    {
        lifeImg[lifeCount].SetActive(false);
        lifeCount++;
    }

    public void Stage_02_PlayerDie()
    {
        int nowMeter = meter.meter;
        panel_GameOver.SetActive(true);
        nowTimerText.text = $"Now\n{nowMeter}m";
        
        if (nowMeter > PlayerPrefs.GetInt("Meter"))
        {
            PlayerPrefs.SetInt("Meter", nowMeter);
        }
        int bestMeter = PlayerPrefs.GetInt("Meter");
        bestTimerText.text = $"Best\n{bestMeter}m";
    }
}

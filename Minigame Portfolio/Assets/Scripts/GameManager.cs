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


    void Start()
    {
        
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
        if (lifeCount >= 3)
        {
            //Destroy(gameObject);
            player.Die();
            lifeCount = 0;
            panel_GameOver.SetActive(true);
            Time.timeScale = 0;
            nowTimerText.text = timer.timerText.text;
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
        panel_GameOver.SetActive(true);
        nowTimerText.text = $"{meter.meter}m";
    }
}

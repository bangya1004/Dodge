using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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


    void Start()
    {
        
    }

    void Update()
    {
        playerDie();
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
}

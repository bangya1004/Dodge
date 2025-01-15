using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lifeCount = 0; 

    [SerializeField]
    private GameObject[] lifeImg;
    [SerializeField]
    private GameObject panel_GameOver;
    [SerializeField]
    private PlayerMovement player;


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
            // 게임 오버 처리
        }
    }

    public void playerCollider()
    {
        lifeImg[lifeCount].SetActive(false);
        lifeCount++;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    void Update()
    {
        Pause();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Continue()
    {
        if (Time.timeScale == 0f) Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
            }
        }
    }
}

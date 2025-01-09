using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{  
    void Update()
    {
        TitleToLobby();
    }

    void TitleToLobby()
    {
        if (SceneManager.GetActiveScene().name == "Title" && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Lobby");
            UnityEngine.Debug.Log("씬 옮김");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{  
    private void Update()
    {
        TitleToLobby();
    }

    private void TitleToLobby()
    {
        if (SceneManager.GetActiveScene().name == "Title" && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Lobby");
            UnityEngine.Debug.Log("씬 옮김");
        }
    }
}

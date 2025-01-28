using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel_StageSelect;
    [SerializeField]
    private GameObject panel_Setting;
    [SerializeField]
    private Button[] SelectGameButtons;
    [SerializeField]
    private Button[] interactable_Buttons;


    public void OnPanel_Middle()
    {
        panel_StageSelect.SetActive(true);
    }
    public void OffPanel_Middle()
    {
        panel_StageSelect.SetActive(false);
    }
    public void SelectGame(int nums)
    {
        for (int i = 0; i < SelectGameButtons.Length; i++)
        {
            SelectGameButtons[i].interactable = true;
        }
        SelectGameButtons[nums].interactable = false;
    }
    public void GamePlay()
    {
        if (SelectGameButtons[0].interactable == false)
        {
            SceneManager.LoadScene("Stage_Avoid");
        }
        else if (SelectGameButtons[1].interactable == false)
        {
            SceneManager.LoadScene("Stage_02");
        }
        else if (SelectGameButtons[2].interactable == false)
        {
            SceneManager.LoadScene("Stage_03");
        }
        else if (SelectGameButtons[3].interactable == false)
        {
            SceneManager.LoadScene("Stage_04");
        }
    }
    public void StageToLobby()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1;
    }
    public void ReStartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void OnSetting()
    {
        panel_Setting.SetActive(true);
        for (int i = 0; i < interactable_Buttons.Length; i++)
        {
            interactable_Buttons[i].interactable = false;
        }
    }
    public void OffSetting()
    {
        panel_Setting.SetActive(false);
        for (int i = 0; i < interactable_Buttons.Length; i++)
        {
            interactable_Buttons[i].interactable = true;
        }
    }
}

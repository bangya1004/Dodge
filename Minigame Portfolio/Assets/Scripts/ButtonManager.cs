using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel_StageSelect;

    public void OnPanel_Middle()
    {
        panel_StageSelect.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    GameManager GM;
    TextMeshProUGUI modeText;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }
    
    public void Change(int newMode)
    {
        GM.currentMode = (GameManager.Mode)newMode;
        modeText.text = newMode.ToString();
    }

}

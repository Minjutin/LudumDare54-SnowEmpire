using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{

    ImageUI imageUi;

    private void Awake()
    {
        imageUi = FindObjectOfType<ImageUI>();
    }

    public void Win()
    {
        GameManager.GM.AudioM.StopBattleMusic();
        imageUi.won.SetActive(true);
    }

    public void Lose()
    {
        GameManager.GM.AudioM.StopBattleMusic();
        imageUi.gameover.SetActive(true);
    }
}

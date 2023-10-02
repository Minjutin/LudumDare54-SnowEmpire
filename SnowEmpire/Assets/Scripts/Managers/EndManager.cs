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
        imageUi.won.SetActive(true);
    }

    public void Lose()
    {
        imageUi.gameover.SetActive(true);
    }
}

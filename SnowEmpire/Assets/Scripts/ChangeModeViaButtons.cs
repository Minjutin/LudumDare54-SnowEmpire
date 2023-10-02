using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeModeViaButtons : MonoBehaviour
{

    public TextMeshProUGUI modeText;


    public void Change(int newMode)
    {
        GameManager.GM.AudioM.PlayClickSound();

        GameManager.GM.currentMode = (GameManager.Mode)newMode;
        modeText.text = ((GameManager.Mode)newMode).ToString();


        switch (newMode)
        {
            case 0: //buy
                GameManager.GM.BuyM.CheckWhatCanBeBought();
                break;
            case 1: //dig
                GameManager.GM.DigM.CheckWhatCanBeDigged();
                break;
        }

        //Iterate every tile
        foreach (KeyValuePair<(int, int), Tile> tile in GameManager.GM.GridM.tileGrid)
        {
            tile.Value.EnablePrice(newMode == 0);
            tile.Value.EnableCanBeTunneled(newMode == 1);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeMode : MonoBehaviour
{

    public TextMeshProUGUI modeText;


    public void Change(int newMode)
    {
        GameManager.GM.currentMode = (GameManager.Mode)newMode;
        modeText.text = ((GameManager.Mode)newMode).ToString();

        //Iterate every tile
        foreach(KeyValuePair<(int,int), Tile> tile in GameManager.GM.GridM.tileGrid)
        {
            tile.Value.EnablePrice(newMode == 1);
        }

        //switch (newMode)
        //{
        //    case 0: //build
        //        break;
        //    case 1: //buy

        //        break;
        //    case 2: //dig
        //        break;
        //}

    }

}

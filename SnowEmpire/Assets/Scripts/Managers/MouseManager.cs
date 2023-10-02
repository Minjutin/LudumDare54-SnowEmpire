using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    Tile tileClicked; 



    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) &&
            mousePos.x < GameManager.GM.GridM.width * 0.5f && mousePos.x > -GameManager.GM.GridM.width * 0.5f
            && mousePos.y < GameManager.GM.GridM.height * 0.5f && mousePos.y > -GameManager.GM.GridM.height * 0.5f)
        {
            tileClicked = GameManager.GM.GridM.GetTileFromPos(mousePos.x, mousePos.y) ;

            switch (GameManager.GM.currentMode)
            {

                case GameManager.Mode.Buy:
                    //If player owns the tile they clicked, spawn a castle.
                    if (tileClicked.owned && !tileClicked.builtOn)
                    {
                        GameManager.GM.BuildM.TryToSpawnSnowCastle(tileClicked);
                    }

                    //If player doesn't own the tile they clicked, buy the tile.
                    if (!tileClicked.owned)
                    {
                        GameManager.GM.BuyM.TryToBuy(tileClicked);
                    }
                        
                    break;


                case GameManager.Mode.Dig:

                    //If player doesn't own the tile they clicked, dig
                    if (!tileClicked.owned)
                    {
                        GameManager.GM.DigM.Dig(tileClicked);
                    }

                    break;
            }


        }
    }
}

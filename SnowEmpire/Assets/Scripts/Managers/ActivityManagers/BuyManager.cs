using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void TryToBuy(Tile tile)
    {

        if (tile.canBeBought)
        {
            if (tile.price <= GameManager.GM.PlayerM.toysOwned)
            {
                //Add snow to player
                GameManager.GM.PlayerM.AddSnow(tile.amountOfSnow);

                //Take toys
                GameManager.GM.PlayerM.AddToys(-tile.price);

                //Buy tile
                tile.Buy();

                CheckWhatCanBeBought();
            }

            else
            {
                StartCoroutine(GameManager.GM.UIM.ShowErrorMessage("You don't have enough toys to buy this land."));
            }
        }

    }

    public void CheckWhatCanBeBought()
    {
        //Check if there is castle/land close enough
        foreach (KeyValuePair<(int, int), Tile> tile in GameManager.GM.GridM.tileGrid)
        {
            tile.Value.canBeTunneled = false;

            if (tile.Value.amountOfSnow > 0)
            {
                //Check if it is owned
                foreach (Tile neighbor in tile.Value.nextTiles)
                {
                    //If owned, there is no further problems
                    if (neighbor.owned || neighbor.tunneled)
                    {
                        tile.Value.canBeBought= true;
                        break;
                    }
                }
                tile.Value.EnablePrice(true);
            }

        }


    }
}

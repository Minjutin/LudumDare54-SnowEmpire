using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void TryToBuy(Tile tile)
    {

        if(tile.price <= GameManager.GM.PlayerM.toysOwned)
        {
            //Add snow to player
            GameManager.GM.PlayerM.AddSnow(tile.amountOfSnow);

            //Take toys
            GameManager.GM.PlayerM.AddToys(-tile.price);

            //Buy tile
            tile.Buy();
        }


    }
}

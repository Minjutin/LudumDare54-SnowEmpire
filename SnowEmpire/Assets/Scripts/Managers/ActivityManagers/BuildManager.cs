using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public GameObject castlePrefab;
    public Transform castles;

    [SerializeField] int castlePrice = 5;

  
    public void TryToSpawnSnowCastle(Tile tile)
    {

        //If player has enough money, spawn.
        if (castlePrice <= GameManager.GM.PlayerM.snowOwned)
        {
            //Spawn
            SpawnCastle(tile);

            //Take snow
            GameManager.GM.PlayerM.AddSnow(-castlePrice);
        }
        //If no enough money
        else
        {
            StartCoroutine(GameManager.GM.UIM.ShowErrorMessage("You don't have enough snow to build a castle."));
        }

    }

    //You can only build if there is a tunnel or caste in next to it.
    public void SpawnCastle(Tile tile)
    {
        GameObject castle = Instantiate(castlePrefab, tile.transform.position+new Vector3(0,0.4f), Quaternion.identity);
        castle.transform.parent = castles;
        castle.name = "Castle " + tile.x + ", " + tile.y;

        tile.builtOn = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public List<Castle> castleList = new();

    public GameObject castlePrefab;
    public Transform castles;

    public int castlePrice = 5;
    [SerializeField] Sprite firstCastle;

  
    public void TryToSpawnSnowCastle(Tile tile)
    {

        //If player has enough money, spawn.
        if (castlePrice <= GameManager.GM.PlayerM.snowOwned)
        {
            //Spawn
            SpawnCastle(tile);

            tile.builtOn = true;
            //Take snow
            tile.EnablePrice(false);
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

        GameManager.GM.AudioM.PlaySnow();
        GameObject castle = Instantiate(castlePrefab, tile.transform.position+new Vector3(0,0.4f), Quaternion.identity);
        castle.transform.parent = castles;
        castle.name = "Castle " + tile.x + ", " + tile.y;
        castleList.Add(castle.GetComponent<Castle>());

        if (GameManager.GM.PlayerM.snowOwned < 1)
        {
            castle.GetComponent<SpriteRenderer>().enabled = false;
        }

        tile.builtOn = true;
    }
}

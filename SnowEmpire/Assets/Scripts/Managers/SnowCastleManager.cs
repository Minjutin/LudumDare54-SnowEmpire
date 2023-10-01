using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCastleManager : MonoBehaviour
{

    public GameObject castlePrefab;
    public Transform castles;

    // Start is called before the first frame update
    public void SpawnSnowCastle(Tile tile)
    {
        GameObject castle = Instantiate(castlePrefab, tile.transform.position, Quaternion.identity);
        castle.transform.parent = castles;
        castle.name = "Castle " + tile.x + ", " + tile.y;
    }

}

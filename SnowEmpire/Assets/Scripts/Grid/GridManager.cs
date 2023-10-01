using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Dictionary<(int, int), Tile> tileGrid { get; private set; } = new();

    public float width, height;

    [SerializeField] GameObject tilePrefab;

    Vector3 upLeftPos;


    void Awake()
    {
        CreateGrid();


    }

    void CreateGrid()
    {

        upLeftPos = new Vector3(-(width - 1) / 2, (height - 1) / 2, 0);

        //Add tiles
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                GameObject newTile = Instantiate(tilePrefab, upLeftPos + new Vector3(i, -j, 0), Quaternion.identity);
                newTile.transform.parent = this.gameObject.transform;
                newTile.name = "Tile " + i + ", " + j;
                newTile.GetComponent<Tile>().x = i;
                newTile.GetComponent<Tile>().y = j;
                tileGrid.Add((i, j), newTile.GetComponent<Tile>());
            }
        }

        //Add neighbours for the tiles
        foreach (KeyValuePair<(int, int), Tile> kvpair in tileGrid)
        {
            AddNeighbors(kvpair.Value);
        }
    }

    public Tile GetTileFromPos(float posx, float posy)
    {
        int x = Mathf.FloorToInt(posx + width / 2);
        int y = Mathf.FloorToInt(-posy + height / 2);

        //Debug.Log("x: " + posx + ", y: " + posy);
        //Debug.Log("index: " + x + ", indey: " + y);



        return tileGrid[(x, y)];
    }


    //Find if tile is next to tunnel or owned tile
    public void AddNeighbors(Tile tile)
    {
        //Check tile under this
        if (tile.x > 0)
            tile.nextTiles.Add(tileGrid[(tile.x - 1, tile.y)]);

        if (tile.x < width - 1)
            tile.nextTiles.Add(tileGrid[(tile.x + 1, tile.y)]);


        if (tile.y < height - 1)
            tile.nextTiles.Add(tileGrid[(tile.x, tile.y + 1)]);

        if (tile.y > 0)
            tile.nextTiles.Add(tileGrid[(tile.x, tile.y - 1)]);
    }
}
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

        upLeftPos = new Vector3(-(width-1)/2, (height-1)/2, 0);

        for(int j = 0; j< height; j++)
        {
            for(int i = 0; i < width; i++)
            {
                GameObject newTile = Instantiate(tilePrefab, upLeftPos + new Vector3(i, -j, 0), Quaternion.identity);
                newTile.transform.parent = this.gameObject.transform;
                newTile.name = "Tile " + i + ", " + j;
                newTile.GetComponent<Tile>().x = i;
                newTile.GetComponent<Tile>().x = j;
                tileGrid.Add((i, j),newTile.GetComponent<Tile>());
            }
        }
    }

    public Tile GetTileFromPos(float posx, float posy)
    {
        int x = Mathf.FloorToInt(posx + width / 2);
        int y = Mathf.FloorToInt(-posy + height / 2);

        //Debug.Log("x: " + posx + ", y: " + posy);
        //Debug.Log("index: " + x + ", indey: " + y);



        return tileGrid[(x,y)];
    }
}

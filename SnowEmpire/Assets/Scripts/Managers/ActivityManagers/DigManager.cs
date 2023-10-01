using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{
    [SerializeField] int toyProb;

    // Update is called once per frame
    public void Dig(Tile tile)
    {
        //If can be dug
        if (tile.canBeTunneled)
        {
            //Check if can be dug
            if (tile.amountOfSnow > 0)
            {

                //Snow business
                GameManager.GM.PlayerM.AddSnow(1);

                tile.Dig();

                //Random generate how many toys
                int rand = Random.Range(0, 100);

                if (rand < toyProb)
                    GameManager.GM.PlayerM.AddToys(1);

                CheckWhatCanBeDigged();
            }
        }

        //If can't 
        else
        {
            StartCoroutine(GameManager.GM.UIM.ShowErrorMessage("You can't reach there."));
        }

    }

    public void CheckWhatCanBeDigged()
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
                    if (neighbor.owned)
                    {
                        tile.Value.canBeTunneled = true;
                        break;
                    }

                    //If not owned,
                    else if (neighbor.tunneled && neighbor.amountOfSnow > 0)
                    {
                        foreach (Tile neighneighbor in neighbor.nextTiles)
                        {
                            if (neighneighbor.builtOn)
                            {
                                tile.Value.canBeTunneled = true;
                            }
                        }
                    }
                }

            }
            tile.Value.EnableCanBeTunneled(true);
        }
        

    }

}

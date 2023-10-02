using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{
    [SerializeField] int toyProb;
    [SerializeField] float dropTime = 0.5f;

    [SerializeField] GameObject snowBall, toy;

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

                StopAllCoroutines();
                GameManager.GM.UIM.errorMessage.enabled = false; 
                StartCoroutine(SpawnParticles(tile, true, rand < toyProb));
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

    IEnumerator SpawnParticles(Tile tile, bool isSnow, bool isSoldier)
    {
        toy.transform.position = new Vector3(-16, 0, 0);
        snowBall.transform.position = new Vector3(-16, 0, 0);

        if (isSoldier)
            toy.transform.position = tile.transform.position;

        if(isSnow)
            snowBall.transform.position = tile.transform.position;
        
        for(float i = 0; i<1; i+=Time.deltaTime/dropTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            snowBall.transform.position = Bezier(i, tile.transform.position, 
                                            tile.transform.position + new Vector3(0.2f, 1),
                                            tile.transform.position + new Vector3(0.4f, 0));
            if (isSoldier)
            {
                toy.transform.position = Bezier(i, tile.transform.position,
                                 tile.transform.position + new Vector3(-0.2f, 1),
                                 tile.transform.position + new Vector3(-0.4f, 0));
            }
 
        }
        yield return new WaitForSeconds(0.2f);
        toy.transform.position = new Vector3(-16, 0, 0);
        snowBall.transform.position = new Vector3(-16, 0, 0);
    }

    public Vector2 Bezier(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        var ab = Vector2.Lerp(a, b, t);
        var bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }
}

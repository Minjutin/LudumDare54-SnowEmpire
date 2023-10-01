using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{
    [SerializeField] int toyProb;

    // Update is called once per frame
    public void Dig(Tile tile)
    {
        GameManager.GM.PlayerM.AddSnow(1);
        tile.takeSnow();

        //Random generate how many toys
        int rand = Random.Range(0,100);

        if (rand < toyProb)
            GameManager.GM.PlayerM.AddToys(1);
    }
}

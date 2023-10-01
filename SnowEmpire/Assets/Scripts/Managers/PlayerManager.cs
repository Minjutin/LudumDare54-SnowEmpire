using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int snowOwned = 0;
    public int toysOwned = 5;

    public Vector3 playerPos;



    private void Start()
    {
        GameManager.GM.UIM.UpdateTexts();
        playerPos = new Vector3(-GameManager.GM.GridM.width/2+2 ,0 ,1);
    }

    //More snow
    public void AddSnow(int amount)
    {
        snowOwned += amount;
        GameManager.GM.UIM.UpdateTexts();
    }

    //More toys
    public void AddToys(int amount)
    {
        toysOwned += amount;
        GameManager.GM.UIM.UpdateTexts();
    }
}

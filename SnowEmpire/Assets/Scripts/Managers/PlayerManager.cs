using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int snowOwned = 0;
    public int toysOwned = 5;

    private void Start()
    {
        GameManager.GM.UIM.UpdateTexts();
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

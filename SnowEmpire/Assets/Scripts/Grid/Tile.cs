using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public int amountOfSnow;
    public int price;

    [Header("booleans")]
    public bool owned = false;
    public bool builtOn = false;
    public bool tunneled = false; 

    //Can be
    public bool canBeTunneled = false;
    public bool canBeBought = false;

    [Header("UI elements")]
    public TextMeshPro priceText;
    public SpriteRenderer tunnelSprite;

    public List<Tile> nextTiles = new();

    private void Start()
    {

        //Get random price and snow amount
        amountOfSnow = Random.Range(1,4) + Random.Range(1, 4);
        price = Random.Range(1,4) + Random.Range(0, 4);
        priceText.text = price + "t";
    }

    public void ChangeColor(Color32 newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }


    public void Buy()
    {
        owned = true;
        ChangeColor(new Color32(150, 140, 120, 255));
        amountOfSnow = 0;
        EnablePrice(false);
    }

    public void Dig()
    {
        //Enable tunneled
        tunneled = true;

        //Dig
        amountOfSnow--;

        if(amountOfSnow == 0)
        {
            ChangeColor(new Color32(0, 0, 0, 255));
            GameManager.GM.GridM.deadTiles++;
        }
    }


    // --------------- Enable -------------------------

    public void EnablePrice(bool enabled)
    {
        if (owned || !canBeBought || amountOfSnow < 1)
        {
            enabled = false;
        }
        priceText.enabled = enabled;
    }

    public void EnableCanBeTunneled(bool enabled)
    {
        if (owned || !canBeTunneled || amountOfSnow < 1) {
            enabled = false;
        }
        tunnelSprite.enabled = enabled;
    }
}

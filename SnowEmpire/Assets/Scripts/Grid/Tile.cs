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
    public TextMeshPro snowAroundText;

    public Sprite ownedSprite;

    public List<Tile> nextTiles = new();

    private void Awake()
    {

        //Get random price and snow amount
        amountOfSnow = Random.Range(1,3) + Random.Range(1, 3);
        price = Random.Range(1,4) + Random.Range(0, 4);
        priceText.text = price + "";
    }

    public void ChangeGraphics()
    {
        GetComponent<SpriteRenderer>().sprite = ownedSprite;
    }


    public void Buy()
    {
        owned = true;
        amountOfSnow = 0;
        ChangeGraphics();     
        EnablePrice(false);
    }

    public void BuyWithoutGraphicChange()
    {
        owned = true;
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
            GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
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
        priceText.gameObject.SetActive(enabled);
        if (price > GameManager.GM.PlayerM.toysOwned)
        {
            priceText.color = Color.red;
        }
        else
            priceText.color = Color.green;

    }

    public void EnableCanBeTunneled(bool enabled)
    {
        if (owned || !canBeTunneled || amountOfSnow < 1) {
            enabled = false;
        }
        tunnelSprite.enabled = enabled;
        snowAroundText.enabled = enabled;

        if (enabled)
        {
            int neighborSnow = 0;
            foreach(Tile neighb in nextTiles)
            {
                neighborSnow += neighb.amountOfSnow;
            }
            snowAroundText.text = neighborSnow + "";

            if (neighborSnow < 6)
                tunnelSprite.color = Color.yellow;
            if (neighborSnow < 4)
                tunnelSprite.color = Color.red;
        }
    }
}

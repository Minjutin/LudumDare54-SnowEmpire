using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;

    public bool owned = false;
    public bool builtOn = false;

    public int amountOfSnow;
    public int price;

    public TextMeshPro priceText;

    private void Start()
    {
        amountOfSnow = Random.Range(6,11);

        price = Random.Range(1,4) + Random.Range(0, 4);
        priceText.text = price + "t";
    }

    public void ChangeColor(Color32 newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    public void takeSnow()
    {
        amountOfSnow--;
    }

    public void Buy()
    {
        owned = true;
        ChangeColor(new Color32(150, 140, 120, 255));
        amountOfSnow = 0;
        EnablePrice(false);
    }

    public void EnablePrice(bool enabled)
    {
        if (owned)
        {
            enabled = false;
        }
        priceText.enabled = enabled;
    }
}

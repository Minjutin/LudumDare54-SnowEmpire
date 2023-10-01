using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int x, y;
    public bool owned = false;

    public int amountOfSnow;

    private void Start()
    {
        amountOfSnow = Random.Range(6,11);
    }
}

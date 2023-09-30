using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager GridM { get; private set; }
    public MouseManager MouseM { get; private set; }

    public Mode currentMode;

    public enum Mode { Build, Buy, Dig}


    void Awake()
    {
        GridM = FindObjectOfType<GridManager>();
        MouseM = FindObjectOfType<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

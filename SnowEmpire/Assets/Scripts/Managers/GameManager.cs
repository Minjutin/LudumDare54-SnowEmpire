using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //MANAGERS
    public GridManager GridM { get; private set; }
    public MouseManager MouseM { get; private set; }

    public PlayerManager PlayerM { get; private set; }

    public SnowCastleManager SnowM { get; private set; }

    public DigManager DigM { get; private set; }  


    //Mode
    public Mode currentMode = Mode.Build;

    public enum Mode { Build, Buy, Dig}


    void Awake()
    {
        GridM = FindObjectOfType<GridManager>();
        MouseM = FindObjectOfType<MouseManager>();
        PlayerM = FindObjectOfType<PlayerManager>();
        SnowM = FindObjectOfType<SnowCastleManager>();
        DigM= FindObjectOfType<DigManager>();

        FindObjectOfType<ChangeMode>().Change(0);
    }

}

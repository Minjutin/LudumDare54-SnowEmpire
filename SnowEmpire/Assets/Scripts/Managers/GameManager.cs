using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This instance as a static variable.
    public static GameManager GM;

    //MANAGERS
    public GridManager GridM { get; private set; }
    public MouseManager MouseM { get; private set; }

    public PlayerManager PlayerM { get; private set; }

    public BuildManager BuildM { get; private set; }

    public DigManager DigM { get; private set; }  

    public UIManager UIM { get; private set; }

    public BuyManager BuyM { get; private set; }


    //Mode
    public Mode currentMode = Mode.Build;

    public enum Mode { Build, Buy, Dig}


    void Awake()
    {
        GM = this;

        GridM = FindObjectOfType<GridManager>();
        MouseM = FindObjectOfType<MouseManager>();
        PlayerM = FindObjectOfType<PlayerManager>();
        BuildM = FindObjectOfType<BuildManager>();
        DigM= FindObjectOfType<DigManager>();
        UIM = FindObjectOfType<UIManager>();
        BuyM = FindObjectOfType<BuyManager>();

        FindObjectOfType<ChangeMode>().Change(0);
    }

}

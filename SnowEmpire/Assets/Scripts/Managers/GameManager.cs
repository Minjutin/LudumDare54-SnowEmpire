using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives = 3;


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
    public AttackManager AttackM { get; private set; }


    //Mode
    public Mode currentMode = Mode.Build;

    public enum Mode { Build, Buy, Dig, ATTACK}

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
        AttackM = FindObjectOfType<AttackManager>();

        FindObjectOfType<ChangeModeViaButtons>().Change(0);
    }


    //START GAME, INITIALIZE START POSITION
    private void Start()
    {
        GridM.CreateGrid();
        GridM.tileGrid[(1, (int)Mathf.Ceil(GridM.height)/2)].Buy();
        GridM.tileGrid[(1, (int)Mathf.Ceil(GridM.height) / 2+1)].Buy();
        BuildM.SpawnCastle(GridM.tileGrid[(1, (int)Mathf.Ceil(GridM.height) / 2)]);
        BuildM.SpawnCastle(GridM.tileGrid[(1, (int)Mathf.Ceil(GridM.height) / 2+1)]);
    }

    private void Update()
    {
        if(GridM.deadTiles >= lives && currentMode != Mode.ATTACK)
        {
            AttackM.LaunchAttackMode();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}

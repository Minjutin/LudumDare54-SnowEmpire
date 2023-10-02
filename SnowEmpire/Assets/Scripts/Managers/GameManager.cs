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

    public EndManager EndM { get; private set; }

    //Mode
    public Mode currentMode = Mode.Dig;

    public enum Mode { Buy = 0, Dig =1, ATTACK = 2}

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
        EndM = FindObjectOfType<EndManager>();
    }


    //START GAME, INITIALIZE START POSITION
    private void Start()
    {
        GridM.CreateGrid();

        StartCoroutine(FindObjectOfType<Tutorial>().StartTutorial());
    }

    private void Update()
    {
        if(GridM.deadTiles >= lives && currentMode != Mode.ATTACK)
        {
            AttackM.LaunchAttackMode();
        }

        //Exit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }

        if (AttackM.currentBullyHp < 1)
        {
            AttackM.StopAllCoroutines();
            EndM.Win();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

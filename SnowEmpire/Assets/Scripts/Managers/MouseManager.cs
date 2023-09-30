using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    GameManager GM;

    Tile tileClicked; 

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) &&
            mousePos.x < GM.GridM.width * 0.5f && mousePos.x > -GM.GridM.width * 0.5f
            && mousePos.y < GM.GridM.height * 0.5f && mousePos.y > -GM.GridM.height * 0.5f)
        {

            tileClicked = GM.GridM.GetTileFromPos(mousePos.x, mousePos.y) ;

            switch (GM.currentMode)
            {
                case GameManager.Mode.Build:
                    
                    break;
                case GameManager.Mode.Buy:
                    break;
                case GameManager.Mode.Dig:
                    break;
            }


        }
    }
}

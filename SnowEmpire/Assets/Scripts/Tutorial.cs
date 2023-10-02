using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{


    [SerializeField] GameObject playerCastle, tutorialBox, skipButton;
    [SerializeField] TextMeshProUGUI tutorialText;

    public bool tutorialSkipped = false;

    // Start is called before the first frame update
    public IEnumerator StartTutorial()
    {
        GameManager.GM.UIM.buttonsOn(false);

        yield return new WaitForSeconds(0.1f);

        EditTutorialText("You want to build a giant snow fortress.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        
        if(!tutorialSkipped)
            GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("Unfortunately, your neighbor bully doesn't let you use your backyard for free.");



        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();



        // --------------- BUY LAND ----------------------------------------------------

        EditTutorialText("Good news: You have a toy you can trade. Use it to buy some land \n<color=#D40505>by clicking a tile with a head icon</color>.");



        Tile firstTile = GameManager.GM.GridM.tileGrid[(1, (int)Mathf.Ceil(GameManager.GM.GridM.height) / 2 + 1)]; 
        Tile secondTile = GameManager.GM.GridM.tileGrid[(1, (int)Mathf.Ceil(GameManager.GM.GridM.height) / 2)];

        firstTile.canBeBought = true;
        firstTile.ChangePrice(1);

        FindObjectOfType<ChangeModeViaButtons>().Change(0);
        GameManager.GM.PlayerM.snowOwned = 10;

        yield return new WaitUntil(()=>firstTile.owned);

        // --------------- BUY CASTLE ----------------------------------------------------


        GameManager.GM.UIM.UpdateTexts();
        EditTutorialText("You got some snow from buying a land. Use it to build a snow fort \n<color=#D40505>by clicking a tile with a snow ball icon</color>.");

        yield return new WaitUntil(() => firstTile.builtOn);

        //Add castles active
        playerCastle.SetActive(true);
        secondTile.BuyWithoutGraphicChange();

        GameManager.GM.PlayerM.snowOwned = 0;
        GameManager.GM.UIM.UpdateTexts();

        secondTile.builtOn = true;



        // --------------- DIG MODE ----------------------------------------------------

        EditTutorialText("You are out of snow. There is no way you can obtain more without making the bully angry.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("Enter to a DIG mode so you can secretly dig tunnels around your castle. \n\n<color=#D40505>Click the DIG-button.</color>");

        GameManager.GM.UIM.buttonsOn(true);

        yield return new WaitUntil(() => GameManager.GM.currentMode == GameManager.Mode.Dig);

        EditTutorialText("The number on a tile shows the total amount of snow left on the tiles <color=#D40505>surrounding it</color> (NOT on the tile itself)");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("Try not to dig too much in one place, or your tunnel will collapse and the bully will notice.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("By digging, you will obtain both snow and lost toys.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("Later, you can use them to buy more castles in BUY-mode. \n\n<color=#D40505>Access buy-mode by clicking the BUY-button.</color>");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        EditTutorialText("Try to buy as many castles as you can without annoying the bully.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);
        if (!tutorialSkipped) GameManager.GM.AudioM.PlayClickSound();

        SkipTutorial();
    }

    public void EditTutorialText(string newText)
    {
        tutorialText.text = newText;
    }

    public void SkipTutorial()
    {
        tutorialSkipped = true;
        tutorialBox.SetActive(false);
        skipButton.SetActive(false);
    }

}

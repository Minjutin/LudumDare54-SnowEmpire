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

        EditTutorialText("Unfortunately, your neighbor bully doesn't let you use your backyard for free.");



        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);



        // --------------- BUY LAND ----------------------------------------------------

        EditTutorialText("Good news: You have a toy you can trade. Buy some land with it \n\n<b>by clicking a tile with a head icon</b>.");



        Tile firstTile = GameManager.GM.GridM.tileGrid[(1, (int)Mathf.Ceil(GameManager.GM.GridM.height) / 2 + 1)]; 
        Tile secondTile = GameManager.GM.GridM.tileGrid[(1, (int)Mathf.Ceil(GameManager.GM.GridM.height) / 2)];

        firstTile.canBeBought = true;
        firstTile.ChangePrice(1);

        FindObjectOfType<ChangeModeViaButtons>().Change(0);
        GameManager.GM.PlayerM.snowOwned = 10;

        yield return new WaitUntil(()=>firstTile.owned);

        // --------------- BUY CASTLE ----------------------------------------------------


        GameManager.GM.UIM.UpdateTexts();
        EditTutorialText("You got some snow from buying a land. Use it to build a snow fort \n\n<b>by clicking a tile with a snow ball icon</b>.");

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

        EditTutorialText("Enter to a DIG mode so you can secretly dig tunnels around your castle. \n\n<b>Click a DIG-button.</b>");

        GameManager.GM.UIM.buttonsOn(true);

        yield return new WaitUntil(() => GameManager.GM.currentMode == GameManager.Mode.Dig);

        EditTutorialText("You can only dig snow around castles. Tiles tell you how much snow is left \n<b>IN THE TILES NEXT TO THEM \n(not diagonally).</b>");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);

        EditTutorialText("Try not to dig too much in one place, or your tunnel will collapse and the bully will notice.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);

        EditTutorialText("By digging, you will obtain both snow and lost toys.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);

        EditTutorialText("Later, you can use them to buy more castles in BUY-mode. \n\n<b>Access buy-mode by clicking a BUY-button.</b>");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);

        EditTutorialText("Try to buy as many castles as you can without annoying the bully.");

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.anyKeyDown || tutorialSkipped);

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

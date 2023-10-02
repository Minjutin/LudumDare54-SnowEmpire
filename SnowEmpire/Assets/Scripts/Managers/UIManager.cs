using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI snowAmount;
    [SerializeField] TextMeshProUGUI toyAmount;
    public TextMeshProUGUI errorMessage;

    [SerializeField] GameObject buttons;
    [SerializeField] GameObject healthBar, barInsides;

    [Header("HP stuff")]
    [SerializeField] Sprite angrySprite;
    [SerializeField] List<Image> hps;


    public void UpdateTexts()
    {
        snowAmount.text = ""+GameManager.GM.PlayerM.snowOwned;
        toyAmount.text = ""+GameManager.GM.PlayerM.toysOwned;
    }

    public IEnumerator ShowErrorMessage(string error)
    {
        if (FindObjectOfType<Tutorial>().tutorialSkipped)
        {
            errorMessage.enabled = true;
            errorMessage.text = error;
            yield return new WaitForSeconds(0.1f);
            errorMessage.enabled = true;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            errorMessage.enabled = false;
        }

    }

    public void LaunchAttackUI()
    {
        buttonsOn(false);
        healthBar.SetActive(true);
    }

    public void HealthAmount(float persentage)
    {
        barInsides.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000.0f*persentage);
    }

    public void buttonsOn(bool isOn)
    {
        buttons.SetActive(isOn);
    }

    public void EditHps()
    {
        for(int i=0; i < GameManager.GM.lives; i++)
        {
            if(i < GameManager.GM.GridM.deadTiles)
            {
                hps[i].sprite = angrySprite;
            }
        }

    }
}

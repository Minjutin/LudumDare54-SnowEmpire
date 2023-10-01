using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI snowAmount;
    [SerializeField] TextMeshProUGUI toyAmount;
    [SerializeField] TextMeshProUGUI errorMessage;

    [SerializeField] GameObject buttons;

    public void UpdateTexts()
    {
        snowAmount.text = ": "+GameManager.GM.PlayerM.snowOwned;
        toyAmount.text = ": "+GameManager.GM.PlayerM.toysOwned;
    }

    public IEnumerator ShowErrorMessage(string error)
    {
        errorMessage.enabled = true;
        errorMessage.text = error;
        yield return new WaitForSeconds(0.1f);
        errorMessage.enabled = true;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        errorMessage.enabled = false;
    }

    public void LaunchAttackUI()
    {
        buttons.SetActive(false);
    }
}

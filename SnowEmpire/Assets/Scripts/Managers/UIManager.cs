using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI snowAmount;
    [SerializeField] TextMeshProUGUI toyAmount;

    public void UpdateTexts()
    {
        snowAmount.text = ": "+GameManager.GM.PlayerM.snowOwned;
        toyAmount.text = ": "+GameManager.GM.PlayerM.toysOwned;
    }
}

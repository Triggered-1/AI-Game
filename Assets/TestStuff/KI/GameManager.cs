using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI wheatText;
    [SerializeField] private TextMeshProUGUI fishText;
    [SerializeField] private TextMeshProUGUI breadText;

    // Start is called before the first frame update
    void Start()
    {
        GameResources.OnGoldAmountChange += ChangeGoldText;
        GameResources.OnStoneAmountChange += ChangeStoneText;
        GameResources.OnWoodAmountChange += ChangeWoodText;
        GameResources.OnWheatAmountChange += ChangeWheatText;
        GameResources.OnFishAmountChange += ChangeFishText;
        GameResources.OnBreadAmountChange += ChangeBreadText;
    }

    public void ChangeGoldText()
    {
        goldText.SetText(GameResources.GetGoldAmount().ToString());
    }

    public void ChangeStoneText()
    {
        stoneText.SetText(GameResources.GetStoneAmount().ToString());
    }

    public void ChangeWoodText()
    {
        woodText.SetText(GameResources.GetWoodAmount().ToString());
    }

    public void ChangeWheatText()
    {
        wheatText.SetText(GameResources.GetWheatAmount().ToString());
    }

    public void ChangeFishText()
    {
        fishText.SetText(GameResources.GetFishAmount().ToString());
    }

    public void ChangeBreadText()
    {
        breadText.SetText(GameResources.GetBreadAmount().ToString());
    }
}

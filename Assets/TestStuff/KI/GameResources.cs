using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameResources
{
    public static event Action OnGoldAmountChange;
    public static event Action OnWoodAmountChange;
    public static event Action OnStoneAmountChange;
    public static event Action OnWheatAmountChange;
    public static event Action OnFishAmountChange;
    public static event Action OnBreadAmountChange;

    private static int goldAmount; 
    private static int woodAmount; 
    private static int stoneAmount; 
    private static int wheatAmount; 
    private static int breadAmount; 
    private static int fishAmount; 

    public static void AddGoldAmount(int amount)
    {
        goldAmount += amount;
        if (OnGoldAmountChange != null) OnGoldAmountChange();
    }
    
    public static void AddResourceAmount(int amount , ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Stone:
                stoneAmount += amount;
                if (OnStoneAmountChange != null) OnStoneAmountChange();
                break;
            case ResourceType.Gold:
                goldAmount += amount;
                if (OnGoldAmountChange != null) OnGoldAmountChange();
                break;
            case ResourceType.Wood:
                woodAmount += amount;
                if (OnWoodAmountChange != null) OnWoodAmountChange();
                break;
            case ResourceType.Wheat:
                wheatAmount += amount;
                if (OnWheatAmountChange != null) OnWheatAmountChange();
                break;
            case ResourceType.Fish:
                fishAmount += amount;
                if (OnFishAmountChange != null) OnFishAmountChange();
                break;
            case ResourceType.Bread:
                breadAmount += amount;
                if (OnBreadAmountChange != null) OnBreadAmountChange();
                break;
            default:
                break;
        }
    }

    public static int GetGoldAmount()
    {
        return goldAmount;
    }

    public static int GetStoneAmount()
    {
        return stoneAmount;
    }

    public static int GetWoodAmount()
    {
        return woodAmount;
    }

    public static int GetWheatAmount()
    {
        return wheatAmount;
    }

    public static int GetFishAmount()
    {
        return fishAmount;
    }

    public static int GetBreadAmount()
    {
        return breadAmount;
    }
}

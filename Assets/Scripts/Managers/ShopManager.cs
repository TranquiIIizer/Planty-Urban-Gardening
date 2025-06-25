using System;
using Managers;
using Plants;
using UI.Tabs.Shop;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public static Action<PlantScriptableObject> OnItemBuy;
    public void OnItemBought()
    {
        int value = CurrencyManager.Instance.GetCurrentMoney();
        int itemPrice = GetComponentInChildren<ShopDetailsPanel>().plant.GetSeedPrice();
        if (value >= itemPrice)
        {
            Debug.Log("Bought");
            OnItemBuy?.Invoke(GetComponentInChildren<ShopDetailsPanel>().plant);
            CurrencyManager.Instance.RemoveMoney(itemPrice);
        }
    }
}


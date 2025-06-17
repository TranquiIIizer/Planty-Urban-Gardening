using System;
using Plants;
using UnityEngine;

public class ShopCardManager : Singleton<ShopCardManager>
{
    private int cardCount;
    
    private void Start()
    {
        SOContainer container = ScriptableObject.CreateInstance<SOContainer>();
        cardCount = container.Plants.Count;
        InstantiateShopContent(container);
        
    }

    private void InstantiateShopContent(SOContainer container)
    {
        foreach (PlantScriptableObject plantObject in container.Plants)
        {
            
        }
    }
}

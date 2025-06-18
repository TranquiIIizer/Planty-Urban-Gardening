using System;
using System.Collections.Generic;
using System.Linq;
using Plants;
using UnityEngine;

namespace UI.Tabs.Shop
{
    public class ShopCardListFetcher : MonoBehaviour
    {
        [SerializeField] private GameObject shopCardListPrefab;
        [SerializeField] private PlantFullListContainerSO plantFullListContainer;
        [SerializeField] private List<PlantScriptableObject> plantScriptableObjects;
        
        //To remove
        public PlantScriptableObject[] initialPlants;

        private void Start()
        {
            LoadStartingShopCards(initialPlants);
        }

        private void LoadStartingShopCards(PlantScriptableObject[] initialPlants)
        {
            foreach (var plant in initialPlants)
            {
                ShopCardHandler card = Instantiate(shopCardListPrefab, transform, false).GetComponent<ShopCardHandler>();
                card.SetCardData(plant.GetSeedSprite(), plant.GetPlantName(), plant);
            }
        }
        
        private void AddNewPlantSeedsToShopList(PlantScriptableObject[] plants)
        {
            foreach (var plant in plants)
            {
                if (!plantScriptableObjects.Contains(plant))
                    plantScriptableObjects.Add(plant);
            }
            RefreshShopList();
        }

        private void RefreshShopList()
        {
            
        }
    }
}

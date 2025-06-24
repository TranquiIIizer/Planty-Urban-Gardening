using System.Collections.Generic;
using Items;
using Plants;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class InventoryItemsManager : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private GameObject inventorySlotPrefab;
        [SerializeField] private GameObject quickAccessInventory;
        [SerializeField] private GameObject inventorySlotParent;
        private List<InventorySlot> inventorySlots = new();
        private List<InventorySlot> quickAccessSlots = new();

        private void Awake() => ShopManager.OnItemBuy += AddItemOnBuyFromShop;
        private void OnDestroy() => ShopManager.OnItemBuy -= AddItemOnBuyFromShop;

        private void Start()
        {
            quickAccessSlots.AddRange(quickAccessInventory.GetComponentsInChildren<InventorySlot>());
            inventorySlots.AddRange(GetComponentsInChildren<InventorySlot>());
        }

        private void AddItemOnBuyFromShop(PlantScriptableObject plant)
        {
            if (!QuickAccessInventoryAddItem(plant))
            {
                if (!InventoryAddItem(plant))
                {
                    InstantiateNewSlotAndAddItem(plant);
                }
            }
        }

        private bool QuickAccessInventoryAddItem(PlantScriptableObject plant)
        {
            foreach (var slot in quickAccessSlots)
            {
                Debug.Log(!slot.GetComponentInChildren<Item>());
                if (!slot.GetComponentInChildren<Item>())
                {
                    SpawnItem(plant, slot);
                    Debug.Log("item spawned quick access slot");
                    return true;
                }
            }
            return false;
        }

        private bool InventoryAddItem(PlantScriptableObject plant)
        {
            foreach (var slot in inventorySlots)
            {
                Debug.Log(!slot.GetComponentInChildren<Item>());
                if (!slot.GetComponentInChildren<Item>())
                {
                    SpawnItem(plant, slot);
                    return true;
                }
            }
            
            return false;
        }

        private void InstantiateNewSlotAndAddItem(PlantScriptableObject plant)
        {
            Debug.Log("Instantiating new slot and add item");
            var newSlot = Instantiate(inventorySlotPrefab, inventorySlotParent.transform);
            InventorySlot inventorySlot = newSlot.GetComponent<InventorySlot>();
            SpawnItem(plant, inventorySlot);
        }

        private void SpawnItem(PlantScriptableObject plant, InventorySlot slot)
        {
            Item item = Instantiate(itemPrefab, slot.transform, false).GetComponent<Item>();
            Image image = item.gameObject.GetComponentInChildren<Image>();
            image.sprite = plant.GetSeedSprite();
            item.SetPlantDetails(plant);
            item.SetItemType(ItemType.Seed);
        }
    }
}

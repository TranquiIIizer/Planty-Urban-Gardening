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
            Debug.Log("Adding item");
            foreach (var slot in quickAccessSlots)
            {
                if (!slot.GetComponentInChildren<Item>())
                {
                    ItemSetter(plant, slot);
                    break;
                }
                else
                {
                    Debug.Log("Can't add to QA slot");
                    foreach (var inventorySlot in inventorySlots)
                    {
                        if (!slot.GetComponentInChildren<Item>())
                        {
                            ItemSetter(plant, inventorySlot);
                            Debug.Log("There is no free inventory slot");
                            break;
                        }
                        else
                        {
                            Debug.Log("Inventory Slot instantiated and item added");
                            InventorySlot inventorySlotNew = Instantiate(inventorySlotPrefab, inventorySlot.transform.parent, false).GetComponent<InventorySlot>();
                            ItemSetter(plant, inventorySlotNew);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void ItemSetter(PlantScriptableObject plant, InventorySlot slot)
        {
            Item item = Instantiate(itemPrefab, slot.transform, false).GetComponent<Item>();
            Image image = item.gameObject.GetComponentInChildren<Image>();
            image.sprite = plant.GetSeedSprite();
            item.SetPlantDetails(plant);
            item.SetItemType(ItemType.Seed);
        }
    }
}

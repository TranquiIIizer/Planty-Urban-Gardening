using UnityEngine;

public class InventoryItemsManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; 
    private InventorySlot[] inventorySlots;
    private InventorySlot[] quickAccessSlots;

    private void AddItemOnBuyFromShop()
    {
        foreach (var slot in quickAccessSlots)
        {
            if (!slot.GetComponentInChildren<Item>())
            {
                Item item = Instantiate(itemPrefab, slot.transform, false).GetComponent<Item>();
            }
        }
    }
}

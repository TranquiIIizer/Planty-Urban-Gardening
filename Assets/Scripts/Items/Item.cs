using Plants;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public PlantScriptableObject PlantDetails { get; private set; }
        public ItemType ItemType {get; private set;}
        
        public void SetPlantDetails(PlantScriptableObject plantDetails) =>  PlantDetails = plantDetails;
        public void SetItemType(ItemType itemType) =>  ItemType = itemType;
    }

    public enum ItemType
    {
        Fruit,
        Tool,
        Seed
    }
}

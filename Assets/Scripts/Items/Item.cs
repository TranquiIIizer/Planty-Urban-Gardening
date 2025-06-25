using Plants;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private PlantScriptableObject PlantDetails;
        [SerializeField] private ItemType ItemType;
        
        public void SetPlantDetails(PlantScriptableObject plantDetails) =>  PlantDetails = plantDetails;
        public void SetItemType(ItemType itemType) =>  ItemType = itemType;
        
        
        public ItemType GetItemType() => ItemType;
        public PlantScriptableObject GetPlantDetails() => PlantDetails;
    }
}

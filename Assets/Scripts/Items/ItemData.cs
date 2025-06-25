using Plants;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
    public class ItemData : ScriptableObject
    {
        public ItemType itemType;
        public Sprite image;
        public PlantScriptableObject plantDetails;
    }

    public enum ItemType
    {
        Fruit,
        Tool,
        Seed
    }
}
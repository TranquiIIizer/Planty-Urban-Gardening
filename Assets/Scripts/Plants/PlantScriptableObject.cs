using System;
using UnityEngine;

namespace Plants
{
    [CreateAssetMenu(fileName = "PlantData", menuName = "Planty/PlantData")]
    public class PlantScriptableObject : ScriptableObject
    {
        [SerializeField] private string plantName;
        [SerializeField] private LightningRequirements lightningRequirements;
        [SerializeField] private Humidity preferedHumidity;
        [SerializeField] private int seedPrice;
        [SerializeField] private int singleFruitPrice;
        [SerializeField] private int daysToFullyGrown;
        [SerializeField] private FruitsPerHarvestRange fruitsPerHarvestRange;
        [SerializeField] private Sprite[] growingProcessSprites = new Sprite[5];
        [SerializeField] private Sprite iconSprite;
        
        public LightningRequirements GetLightningRequirements() => lightningRequirements;
        public Humidity GetPreferedHumidity() => preferedHumidity;
        public int GetSeedPrice() => seedPrice;
        public int GetSingleFruitPrice() => singleFruitPrice;
        public int GetDaysToFullyGrown() => daysToFullyGrown;
        
    }
    
    public enum Humidity
    {
        Low,
        Medium,
        High
    }
    public enum LightningRequirements
    {
        Low,
        Medium,
        High
    }

    [Serializable]
    public struct FruitsPerHarvestRange
    {
        public int min;
        public int max;
    }
}
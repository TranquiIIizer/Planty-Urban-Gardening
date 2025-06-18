using System;
using UnityEngine;

namespace Plants
{
    [CreateAssetMenu(fileName = "PlantData", menuName = "Planty/PlantData")]
    public class PlantScriptableObject : ScriptableObject
    {
        [SerializeField] private string plantName;
        [SerializeField] private string seedsName;
        [SerializeField] private GrowingSeason[] growingSeasons;
        [SerializeField] private int seedPrice;
        [SerializeField] private int singleFruitPrice;
        [Range(0, 28)]
        [SerializeField] private int daysToFullyGrown;
        [SerializeField] private bool isRegrowing;
        [SerializeField] private FruitsPerHarvestRange fruitsPerHarvestRange;
        [SerializeField] private Sprite[] growingProcessSprite;
        [SerializeField] private Sprite regrowingProcessSprite;
        [SerializeField] private Sprite iconSprite;
        [SerializeField] private Sprite seedsSprite;
        [SerializeField] private Sprite[] buffSprites;
        [SerializeField] private Sprite[] debuffSprites;
        
        
        public string GetPlantName() => plantName;
        public string GetSeedsName() => seedsName;
        public int GetSeedPrice() => seedPrice;
        public GrowingSeason[] GetGrowingSeasons() => growingSeasons;
        public int GetSingleFruitPrice() => singleFruitPrice;
        public string GetDaysToFullyGrown() => daysToFullyGrown + " d";
        public Sprite GetSeedSprite() => seedsSprite;
        public string GetSeasonText()
        {
            string seasonText = null;
            foreach (var season in growingSeasons)
            {
                seasonText += $"{season.ToString()}, ";
            }
            return seasonText;
        }

        public Sprite[] GetBuffSprites() => buffSprites;
        public Sprite[] GetDebuffSprites() => debuffSprites;
    }

    public enum GrowingSeason
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    [Serializable]
    public struct FruitsPerHarvestRange
    {
        public int min;
        public int max;
    }
}
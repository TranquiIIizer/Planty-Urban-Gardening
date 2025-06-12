using UnityEngine;

namespace Plants
{
    [CreateAssetMenu(fileName = "PlantData", menuName = "Planty/PlantData")]
    public class PlantScriptableObject : ScriptableObject
    {
        [SerializeField] private LightningRequirements _lightningRequirements;
        [SerializeField] private Humidity _preferedHumidity;
        [SerializeField] private int _seedPrice;
        
        public LightningRequirements GetLightningRequirements() => _lightningRequirements;
        public Humidity GetHumidity() => _preferedHumidity;
        public int GetSeedPrice() => _seedPrice;
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
}
using System;
using Plants;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Tabs.Shop
{
    public class ShopCardHandler : MonoBehaviour, IPointerClickHandler
    {
        private PlantScriptableObject _plant;
        [SerializeField] private Image seedImage;
        [SerializeField] private TextMeshProUGUI seedNameText;
        

        public void SetCardData(Sprite sprite, string text, PlantScriptableObject plant)
        {
            seedImage.sprite = sprite;
            seedNameText.text = text;
            _plant = plant;
        }
        
        public static event Action<PlantScriptableObject> OnClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(_plant);
        }
    }
}

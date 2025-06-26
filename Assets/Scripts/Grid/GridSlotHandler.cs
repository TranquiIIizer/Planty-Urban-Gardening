using System;
using Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class GridSlotHandler : MonoBehaviour, IDropHandler
    {
        private Vector2Int _coords;
        private Plant _plant;
        [SerializeField] private GameObject plantPrefab;
        [SerializeField] private SpriteRenderer plantSpriteRenderer;

        public Action WateredEvent;
        
        public void Initialize(int posX, int posY)
        {
            _coords.x = posX;
            _coords.y = posY;

            gameObject.name = $"Tile {_coords.x} : {_coords.y}";
        }

        public Vector2Int GetCoords() => _coords;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                //Must Refactor
                
                bool isSeed = eventData.pointerDrag.GetComponent<Item>().GetItemType() == ItemType.Seed;
                bool isWateringCan = eventData.pointerDrag.GetComponent<WateringCan>();
                bool isSpade = eventData.pointerDrag.GetComponent<Spade>();
                if (isSeed)
                {
                    _plant = Instantiate(plantPrefab, transform, false).GetComponent<Plant>();
                    Item item = eventData.pointerDrag.gameObject.GetComponent<Item>();
                    _plant.plantData = item.GetPlantDetails();
                    
                    Destroy(item.gameObject);
                }

                if (isWateringCan)
                {
                    WateredEvent?.Invoke();
                }

                if (isSpade)
                {
                    Debug.Log("Szpada");
                    Destroy(_plant.gameObject);
                }
            }
        }
    }
}

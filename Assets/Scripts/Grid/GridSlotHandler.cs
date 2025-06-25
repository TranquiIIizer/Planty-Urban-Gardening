using Items;
using Plants;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class GridSlotHandler : MonoBehaviour, IDropHandler
    {
        private Vector2Int _coords;
        private bool _hasPlant;
        [SerializeField] private SpriteRenderer plantSpriteRenderer;

        private void Start()
        {
            _hasPlant = false;
        }

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
                bool isSeed = eventData.pointerDrag.gameObject.GetComponent<Item>().GetItemType() == ItemType.Seed;
                if (isSeed)
                {
                    GridPlantSpriteUpdater spriteUpdater = GetComponentInChildren<GridPlantSpriteUpdater>();
                    Item item = eventData.pointerDrag.gameObject.GetComponent<Item>();
                    spriteUpdater.InitializePlantSprite(item.GetPlantDetails());
                    
                    Destroy(item.gameObject);
                }
            }
        }
    }
}

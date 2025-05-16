using UnityEngine;

namespace Map
{
    public class GridManager : MonoBehaviour
    {
        public int testInt;
        [SerializeField] private GameObject potSlotPrefab;
        private void Start()
        {
            CreateGrid();
            
        }
        
        private void CreateGrid()
        {
            Vector2 gridSize = SetGridScale(GridSize.Large);
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    InstantiateSlot(x, y);
                    SlotVisibilityController(GridSize.Small);
                }
            }
        }

        private void SlotVisibilityController(GridSize size)
        {
            
        }
        
        private void Upgrade()
        {
            
        }

        private void Degrade()
        {
            
        }
        
        private Vector2 SetGridScale(GridSize size)
        {
            return size switch
            {
                GridSize.Small => new(5, 4),
                GridSize.Medium => new(6, 5),
                GridSize.Large => new(8, 6),
                _ => new(5, 4)
            };

        }
        
        private void InstantiateSlot(int x, int y)
        {
            GameObject slot = Instantiate(potSlotPrefab, new Vector2(x, y), Quaternion.identity);
            slot.GetComponent<SpriteRenderer>().color = GetColor(x + y);
            slot.name = $"Tile: {x} {y}";
        }
        
        private Color GetColor(int index)
        {
            return index % 2 == 0 ? Color.blue : Color.red;
        }
    }
    
    internal enum GridSize
    {
        Small,
        Medium,
        Large
    }
}

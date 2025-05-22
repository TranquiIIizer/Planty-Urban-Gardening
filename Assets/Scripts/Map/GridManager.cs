using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridSize gridSize;
        [SerializeField] private GameObject potSlotPrefab;
        [SerializeField] private List<PlantSlot> plantSlots = new List<PlantSlot>();
        private void Start()
        {
            CreateGrid();
            Camera.main.transform.position = CenterCameraOnGrid(gridSize);
        }
        
        private void CreateGrid()
        {
            Vector2 gridSize = GetGridSize(GridSize.Large);
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    InstantiateSlot(x, y);
                    SlotVisibilityController(GridSize.Large);
                }
            }
        }

        private void SlotVisibilityController(GridSize size)
        {
            foreach (PlantSlot slot in plantSlots)
            {
                Vector2 coords = slot.coords.getCoords;
                if (coords.x > GetGridSize(size).x - 1)
                {
                    slot.gameObject.SetActive(false);
                }
                else if (coords.y > GetGridSize(size).y - 1)
                {
                    slot.gameObject.SetActive(false);
                }
                else 
                    slot.gameObject.SetActive(true);
            }
        }

        private Vector3 CenterCameraOnGrid(GridSize size)
        {
            Vector2 gridSize = GetGridSize(size);
            return new Vector3(gridSize.x / 2 - 0.5f, gridSize.y / 2 - 0.5f, -10);
        }

        private void Upgrade()
        {
            
        }

        private void Degrade()
        {
            
        }
        
        private Vector2 GetGridSize(GridSize size)
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
            GameObject slot = Instantiate(potSlotPrefab, transform, true);
            slot.transform.position = new Vector3(x, y, 0);
            slot.GetComponent<SpriteRenderer>().color = SetColor(x + y);
            slot.name = $"Tile: {x} {y}";
            PlantSlot plantSlot = slot.AddComponent<PlantSlot>();
            plantSlot.coords = new(x, y);
            plantSlots.Add(plantSlot);
        }
        
        private Color SetColor(int index)
        {
            return index % 2 == 0 ? Color.blue : Color.red;
        }

        private void OnValidate()
        {
            SlotVisibilityController(gridSize);
            Camera.main.transform.position = CenterCameraOnGrid(gridSize);
        }
    }
    
    internal enum GridSize
    {
        Small,
        Medium,
        Large
    }
}

using System.Collections.Generic;
using UnityEngine;
using Grid;

namespace Managers
{
    public class GridManager : Singleton<GridManager>
    {
        [SerializeField] private GridSize gridSize;
        [SerializeField] private GameObject potSlotPrefab;
        private List<GridSlotHandler> _plantSlots = new();
        
        private void Start()
        {
            CreateGrid();
            if (Camera.main != null) Camera.main.transform.position = CenterCameraOnGrid(gridSize);
        }
        
        private void CreateGrid()
        {
            Vector2 size = GetGridSize(GridSize.Large);
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    InstantiateSlot(x, y);
                    SlotVisibilityController(GridSize.Small);
                    CenterCameraOnGrid(GridSize.Small);
                }
            }
        }

        private void SlotVisibilityController(GridSize size)
        {
            foreach (GridSlotHandler slot in _plantSlots)
            {
                Vector2Int coords = slot.GetCoords();
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
            Vector2 vector2 = GetGridSize(size);
            CameraProjectionSizeSetter();
            return new Vector3(vector2.x / 2 - 0.5f, vector2.y / 2 - 0.5f, -10);

            void CameraProjectionSizeSetter()
            {
                switch (size)
                {
                    case GridSize.Small:
                        Camera.main.orthographicSize = 2.5f;
                        break;
                    case GridSize.Medium:
                        Camera.main.orthographicSize = 3.0f;
                        break;
                    case GridSize.Large:
                        Camera.main.orthographicSize = 3.5f;
                        break;
                }
            }
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
            
            GridSlotHandler slotData = slot.GetComponent<GridSlotHandler>();
            slotData.Initialize(x, y);
            _plantSlots.Add(slotData);
        }

        private void OnValidate()
        {
            SlotVisibilityController(gridSize);
            if (Camera.main != null) Camera.main.transform.position = CenterCameraOnGrid(gridSize);
        }
    }
    
    internal enum GridSize
    {
        Small,
        Medium,
        Large
    }
}

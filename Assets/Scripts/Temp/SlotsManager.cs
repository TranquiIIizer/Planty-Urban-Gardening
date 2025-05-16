using UnityEngine;

namespace Temp
{
    public class SlotsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _potSlotPrefab;
        [SerializeField] private GridSize _gridSize;
        [SerializeField] private Camera _camera;

        private void Start()
        {
            CreateDefaultGrid();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GridSize previousSize = _gridSize;
                _gridSize = GridAdjustSize(_gridSize, true);

                if (previousSize == _gridSize) 
                {
                    //Prevent Upgrade Mechanic
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GridSize previousSize = _gridSize;
                _gridSize = GridAdjustSize(_gridSize, false);

                if (previousSize == _gridSize)
                {
                    //Prevent Upgrade Mechanic
                }
            }
        }

        private GridSize GridAdjustSize(GridSize size, bool up)
        {
            // Switch does not need threshold values, because upgrade / degrade can't be performed above/below the threshold
            if (up)
            {
                return size switch
                {
                    GridSize.Min => GridSize.Medium,
                    GridSize.Medium => GridSize.Max,
                    _ => size
                };
            } else
            {
                return size switch
                {
                    GridSize.Max => GridSize.Medium,
                    GridSize.Medium => GridSize.Min,
                    _ => size
                };
            }
        }

        private void CreateDefaultGrid()
        {
            Vector2 gridSize = SetGridScale(GridSize.Min);
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    InstantiateSlots(x, y);
                }
            }
            CameraCenterAndFOVSetter();
        }

        private void CameraCenterAndFOVSetter()
        {
            _camera.transform.position = CenterCameraOnGrid(GridSize.Min);
            _camera.orthographicSize = GetCameraFieldOfView(GridSize.Min);
        }

        private void InstantiateSlots(int x, int y)
        {
            GameObject slot = Instantiate(_potSlotPrefab, new Vector2(x, y), Quaternion.identity);
            slot.GetComponent<SpriteRenderer>().color = GetColor(x + y);
            slot.name = $"Tile: {x} {y}";
        }

        private Vector3 CenterCameraOnGrid(GridSize size)
        {
            Vector2 gridSize = SetGridScale(size);
            return new Vector3(gridSize.x / 2 - 0.5f, gridSize.y / 2 - 0.5f, -10);
        }

        private float GetCameraFieldOfView(GridSize size)
        {
            return size switch
            {
                GridSize.Min => 2.5f,
                GridSize.Medium => 3f,
                GridSize.Max => 3.5f,
                _ => 2.5f
            };
        }

        private Vector2 SetGridScale(GridSize size)
        {
            return size switch
            {
                GridSize.Min => new(5, 4),
                GridSize.Medium => new(6, 5),
                GridSize.Max => new(8, 6),
                _ => new(5, 4)
            };

        }

        private Color GetColor(int index)
        {
            return index % 2 == 0 ? Color.blue : Color.red;
        }
    }

    public enum GridSize
    {
        Min, Medium, Max
    }
}
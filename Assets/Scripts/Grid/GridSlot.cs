using UnityEngine;

public class GridSlot : MonoBehaviour
{
    private Vector2Int _coords;

    public void Initialize(int posX, int posY)
    {
        _coords.x = posX;
        _coords.y = posY;

        gameObject.name = $"Tile {_coords.x} : {_coords.y}";
    }

    public Vector2Int GetCoords()
    {
        return _coords;
    }
}

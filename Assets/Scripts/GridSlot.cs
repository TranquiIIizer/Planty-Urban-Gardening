using UnityEngine;

public class GridSlot : MonoBehaviour
{
    public CoordinatesData Coords;

    public GridSlot(CoordinatesData coords)
    {
        Coords  = coords;
    }
    private void Start()
    {
        Debug.Log(Coords.GetCoords);
    }
}

public readonly struct CoordinatesData
{
    readonly int _posX;
    readonly int _posY;

    public CoordinatesData(int posX, int posY)
    {
        this._posX = posX;
        this._posY = posY;
    }

    // Skr�cona wersja public int x {get { return _posX; }}
    public readonly int X => _posX;
    public readonly int Y => _posY;

    public Vector2 GetCoords => new(_posX, _posY);
}

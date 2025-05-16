using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    public CoordinatesData coords = new(1,4);

    private void Start()
    {
        
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

    // Skrócona wersja public int x {get { return _posX; }}
    public readonly int X => _posX;
    public readonly int Y => _posY;
}

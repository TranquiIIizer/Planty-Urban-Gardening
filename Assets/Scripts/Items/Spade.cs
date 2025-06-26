using System;
using Items;
using UnityEngine;

public class Spade : Item, IGardenFieldUsable
{
    public event Action<Item> OnGardenFieldUsable;

    public void Use(Item item)
    {
        OnGardenFieldUsable?.Invoke(this);
    }
}

using System;
using Items;

public interface IGardenFieldUsable
{
    event Action<Item> OnGardenFieldUsable;
    void Use(Item item); 
}

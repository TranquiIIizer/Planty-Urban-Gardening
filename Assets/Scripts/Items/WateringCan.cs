using System;
using UnityEngine;

namespace Items
{
    public class WateringCan : Item, IGardenFieldUsable
    {
        public event Action<Item> OnGardenFieldUsable;

        public void Use(Item item)
        {
            OnGardenFieldUsable?.Invoke(this);
        }
    }
}

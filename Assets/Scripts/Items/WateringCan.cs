using UnityEngine;

namespace Items
{
    public class WateringCan : Item, IGardenFieldUsable
    {
        public void Use(Item item)
        {
            Debug.Log("WateringCan Used");
        }
    }
}

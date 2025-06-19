using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                ItemDrag draggableItem = dropped.GetComponent<ItemDrag>();
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}

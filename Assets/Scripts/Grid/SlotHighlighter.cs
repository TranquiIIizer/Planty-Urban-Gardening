using System.Collections;
using Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class SlotHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject slotHighlighter;
        [SerializeField] private Material freeSlotIndicatorMaterial;
        [SerializeField] private Material occupiedSlotIndicatorMaterial;
        private Material _defaultMaterial;
        private Renderer _renderer;

        private void Start()
        {
            _renderer = slotHighlighter.GetComponent<Renderer>();
            _defaultMaterial = _renderer.material;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            ItemType draggedItemType = eventData.pointerDrag.GetComponent<Item>().GetItemType();
            bool isPlantOnSlot = GetComponentInParent<GridSlotHandler>().GetComponentInChildren<Plant>();

            if (draggedItemType == ItemType.Seed)
            {
                if (isPlantOnSlot)
                    _renderer.material = occupiedSlotIndicatorMaterial;
                else
                    _renderer.material = freeSlotIndicatorMaterial;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _renderer.material = _defaultMaterial;
        }
    }
}

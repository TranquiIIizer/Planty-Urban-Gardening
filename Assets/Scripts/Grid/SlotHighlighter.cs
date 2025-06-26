using System.Collections;
using Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class SlotHighlighter : MonoBehaviour
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

        private void OnMouseEnter()
        {
            if (GetComponentInParent<GridSlotHandler>().GetComponentInChildren<Plant>())
                _renderer.material = occupiedSlotIndicatorMaterial;
            else 
                _renderer.material = freeSlotIndicatorMaterial;
        }

        private void OnMouseExit()
        {
            _renderer.material = _defaultMaterial;
        }
    }
}

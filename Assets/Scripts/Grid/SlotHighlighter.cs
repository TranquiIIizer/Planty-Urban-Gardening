using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class SlotHighlighter : MonoBehaviour, IDropHandler
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

        private IEnumerator OnMouseEnter()
        {
            _renderer.material = freeSlotIndicatorMaterial;
            yield return null;
        }

        private IEnumerator OnMouseExit()
        {
            _renderer.material = _defaultMaterial;
            yield return null;
        }


        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Item Dropped");
        }
    }
}

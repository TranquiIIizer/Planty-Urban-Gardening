using System;
using UnityEngine;

public class SlotHighlighter : MonoBehaviour
{
    [SerializeField] private Material freeSlotIndicatorMaterial;
    [SerializeField] private Material occupiedSlotIndicatorMaterial;
    private Material _defaultMaterial;

    private void Start()
    {
        _defaultMaterial = GetComponent<Renderer>().material;
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material = freeSlotIndicatorMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = _defaultMaterial;
    }
}

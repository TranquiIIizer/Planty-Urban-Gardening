using System;
using UnityEngine;

public class QuickAccessInventory : MonoBehaviour
{
    private Transform _initialPositionParent;

    private void Awake()
    {
        InventoryTabController.OnInventoryTabOpen += SetInventoryPosition;
        InventoryTabController.OnInventoryTabClose += GoBackToInitialPosition;
        _initialPositionParent = transform.parent;
    }

    public void SetInventoryPosition()
    {
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    } 
        
    public void GoBackToInitialPosition() => transform.SetParent(_initialPositionParent);

    private void OnDestroy()
    {
        InventoryTabController.OnInventoryTabOpen -= SetInventoryPosition;
        InventoryTabController.OnInventoryTabClose -= GoBackToInitialPosition;
    }
}

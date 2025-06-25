using System;
using UnityEngine;

public class InventoryTabController : MonoBehaviour, IMenuTab
{
    public static Action OnInventoryTabOpen;
    public static Action OnInventoryTabClose;
    private void OnEnable() => OnInventoryTabOpen?.Invoke();
    
    private void OnDisable() => OnInventoryTabClose?.Invoke();

    public Type GetTabType() => typeof(InventoryTabController);
}

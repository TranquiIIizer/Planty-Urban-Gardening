using System;
using UnityEngine;

public class InventoryTabController : MonoBehaviour, IMenuTab
{
    public Type GetTabType() => typeof(InventoryTabController);
}

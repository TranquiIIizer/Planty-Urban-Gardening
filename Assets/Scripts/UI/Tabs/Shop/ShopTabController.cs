using System;
using UnityEngine;

public class ShopTabController : MonoBehaviour,  IMenuTab
{
    
    
    public Type GetTabType() =>  typeof(ShopTabController);
}

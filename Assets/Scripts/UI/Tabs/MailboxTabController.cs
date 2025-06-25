using System;
using UnityEngine;


public class MailboxTabController : MonoBehaviour, IMenuTab 
{ 
    public Type GetTabType() => typeof(MailboxTabController);
}

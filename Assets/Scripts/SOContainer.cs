using System.Collections.Generic;
using Plants;
using UnityEngine;

[CreateAssetMenu(fileName = "SOContainer", menuName = "Planty/SOContainer")]
public class SOContainer : ScriptableObject
{
    [SerializeField] private List<PlantScriptableObject> plants;
    
    public List<PlantScriptableObject> Plants => plants;
}

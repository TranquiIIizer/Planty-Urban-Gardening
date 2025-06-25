using System.Collections.Generic;
using Plants;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantFullListContainerSO", menuName = "Planty/PlantFullListContainerSO")]
public class PlantFullListContainerSO : ScriptableObject
{
    public List<PlantScriptableObject> plants;
}

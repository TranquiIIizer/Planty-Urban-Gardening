using UnityEngine;

public class Plant : PlantStateMachine
{
    private void Start()
    {
        Begin(new PlantGrowingState(this));
    }
}

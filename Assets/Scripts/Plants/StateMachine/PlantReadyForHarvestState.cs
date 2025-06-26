using UnityEngine;

public class PlantReadyForHarvestState : PlantState
{
    public PlantReadyForHarvestState(PlantStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        base.Enter();

        GameTimeManager.TimeTickEvent += Update;
        Debug.Log("Ready to harvest");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Still waiting for harvest");
    }

    public override void Exit() 
    {
        base.Exit();
        GameTimeManager.TimeTickEvent -= Update;
    }
}

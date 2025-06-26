using UnityEngine;

public class PlantDeathState : PlantState
{
    public PlantDeathState(PlantStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered PlantDeathState");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

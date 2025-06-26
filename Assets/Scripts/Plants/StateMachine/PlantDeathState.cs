using UnityEngine;

public class PlantDeathState : PlantState
{
    public PlantDeathState(PlantStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Plant is dead");
    }

    public override void Exit()
    {
        base.Exit();
    }
}

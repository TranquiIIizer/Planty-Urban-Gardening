using UnityEngine;

public class PlantDryState : PlantState
{
    private int _driedDays;
    public PlantDryState(PlantStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        base.Enter();
        GameTimeManager.TimeTickEvent += Update;
    }

    public override void Update()
    {
        base.Update();
        
        _driedDays++;
        if (_driedDays > 4)
        {
            GameTimeManager.TimeTickEvent -= Update;
            _plantStateMachine.SetState(new PlantDeathState(_plantStateMachine));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

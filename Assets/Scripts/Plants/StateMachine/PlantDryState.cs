using Grid;
using UnityEngine;

public class PlantDryState : PlantState
{
    private int _driedDaysCount;
    public PlantDryState(PlantStateMachine stateMachine) : base(stateMachine){}
    
    private PlantWiltController plantWiltController;

    public override void Enter()
    {
        base.Enter();
        GameTimeManager.TimeTickEvent += Update;

        _plantStateMachine.GetComponentInParent<GridSlotHandler>().WateredEvent += GoBackToGrowingState;

        plantWiltController = _plantStateMachine.GetComponentInChildren<PlantWiltController>();
        plantWiltController.tintJumpValue = 1f / _driedDaysCount;
    }

    public override void Update()
    {
        base.Update();
        
        Debug.Log(_driedDaysCount);
        _driedDaysCount++;
        plantWiltController.WiltProgressSet();
        
        if (_driedDaysCount > 4)
        {
            GameTimeManager.TimeTickEvent -= Update;
            _plantStateMachine.SetState(new PlantDeathState(_plantStateMachine));
        }
    }

    public override void Exit()
    {
        base.Exit();
        _driedDaysCount = 0;
        _plantStateMachine.GetComponentInParent<GridSlotHandler>().WateredEvent -= GoBackToGrowingState;
    }

    private void GoBackToGrowingState()
    {
        GameTimeManager.TimeTickEvent -= Update;
        plantWiltController.WiltReset();
        _plantStateMachine.SetState(new PlantGrowingState(_plantStateMachine));
    }
}

using Grid;
using UnityEngine;

public class PlantGrowingState : PlantState
{
    private GridPlantSpriteUpdater plantSpriteUpdater;
    private int daysWithoutWatering;
    public PlantGrowingState(PlantStateMachine stateMachine) : base(stateMachine){}
    
    public override void Enter()
    {
        base.Enter();

        _plantStateMachine.GetComponentInParent<GridSlotHandler>().WateredEvent += ResetDrying;
        
        GameTimeManager.TimeTickEvent += Update;
        daysWithoutWatering = 0;
        plantSpriteUpdater = _plantStateMachine.GetComponentInChildren<GridPlantSpriteUpdater>();
    }

    public override void Update()
    {
        base.Update();
        
        daysWithoutWatering++;
        plantSpriteUpdater.DaysToFullyGrownUpdate();
        
        if (daysWithoutWatering > 5)
        {
            GameTimeManager.TimeTickEvent -= Update;
            _plantStateMachine.SetState(new PlantDryState(_plantStateMachine));
        }
    }

    public override void Exit()
    {
        base.Exit();
        _plantStateMachine.GetComponentInParent<GridSlotHandler>().WateredEvent -= ResetDrying;
    }

    private void ResetDrying()
    {
        Debug.Log("Drying Reset");
        daysWithoutWatering = 0;
    }
}

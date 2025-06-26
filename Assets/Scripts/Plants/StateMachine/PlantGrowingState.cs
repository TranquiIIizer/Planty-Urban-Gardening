using Grid;
using Unity.VisualScripting;
using UnityEngine;

public class PlantGrowingState : PlantState
{
    private GridPlantSpriteUpdater plantSpriteUpdater;
    private int daysWithoutWatering;
    private int daysToFullyGrown;
    private int growDaysCount = 0;
    public PlantGrowingState(PlantStateMachine stateMachine) : base(stateMachine){}
    
    public override void Enter()
    {
        base.Enter();

        _plantStateMachine.GetComponentInParent<GridSlotHandler>().WateredEvent += ResetDrying;
        daysToFullyGrown = _plantStateMachine.GetComponent<Plant>().plantData.GetDaysToFullyGrownInt();
        Debug.Log(daysToFullyGrown);
        
        GameTimeManager.TimeTickEvent += Update;
        daysWithoutWatering = 0;
        plantSpriteUpdater = _plantStateMachine.GetComponentInChildren<GridPlantSpriteUpdater>();
    }

    public override void Update()
    {
        base.Update();

        growDaysCount++;
        if (growDaysCount == daysToFullyGrown)
        {
            GameTimeManager.TimeTickEvent -= Update;
            _plantStateMachine.SetState(new PlantReadyForHarvestState(_plantStateMachine));
        }


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

using Grid;
using UnityEngine;

public class PlantGrowingState : PlantState
{
    private GridPlantSpriteUpdater plantSpriteUpdater;
    public PlantGrowingState(PlantStateMachine stateMachine) : base(stateMachine){}
    
    public override void Enter()
    {
        base.Enter();
        GameTimeManager.TimeTickEvent += Update;
        plantSpriteUpdater = _plantStateMachine.GetComponentInChildren<GridPlantSpriteUpdater>();
        Debug.Log(plantSpriteUpdater.gameObject.name);
    }

    public override void Update()
    {
        base.Update();
        
    }

    public override void Exit()
    {
        base.Exit();
        
        GameTimeManager.TimeTickEvent -= Update;
    }
}

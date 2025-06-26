using Grid;
using Items;
using Plants;

public class Plant : PlantStateMachine
{
    public PlantScriptableObject plantData;
    private GridPlantSpriteUpdater _plantSpriteUpdater;
    
    private void Start()
    {
        Begin(new PlantGrowingState(this));
        _plantSpriteUpdater = GetComponentInChildren<GridPlantSpriteUpdater>();
    }
}

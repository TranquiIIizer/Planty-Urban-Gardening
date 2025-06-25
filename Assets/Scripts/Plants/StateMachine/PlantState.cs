using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public abstract class PlantState
{
    protected PlantStateMachine _plantStateMachine;

    public PlantState(PlantStateMachine stateMachine)
    {
        _plantStateMachine = stateMachine;
    }

    public virtual void Enter() {}
    public virtual void Update() {}
    public virtual void Exit() {}
}

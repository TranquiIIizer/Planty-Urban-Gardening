using System;
using UnityEngine;

[Serializable]
public class PlantStateMachine : MonoBehaviour
{
    [SerializeField] public PlantStateStack stack;
    public PlantState CurrentState {get; private set;}
    
    private PlantState _previousState;

    private void Start()
    {
        Begin(new PlantGrowingState(this));
    }

    public void Begin(PlantState state)
    {
        Debug.Log(state);
        stack = new PlantStateStack();
        stack.Push(state);
        CurrentState = state;
        CurrentState.Enter();
    }

    public void SetState(PlantState state)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        
        CurrentState = state;
        stack.Push(state);
        CurrentState.Enter();
    }

    public void RedoState()
    {
        if (stack.Count() == 0)
            return;
        
        CurrentState.Exit();
        CurrentState = null;
        stack.Pop();
        
        if (stack.Count() == 0)
            return;
        
        CurrentState = stack.Peek();
        CurrentState.Enter();
    }

    private void Update()
    {
        Debug.Log(CurrentState);
        if (CurrentState != null)
            return;
        CurrentState.Update();
    }
}

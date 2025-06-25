using System.Collections.Generic;
using UnityEngine;

public class PlantStateStack
{
    private List<PlantState> _stack = new();
    public void Push(PlantState state) => _stack.Add(state);

    public PlantState Pop()
    {
        PlantState lastState = Peek();
        _stack.RemoveAt(_stack.Count - 1);
        return lastState;
    }

    public PlantState Peek()
    {
        if (_stack.Count == 0) 
            return null;
        return _stack[^1];
    }
    
    public int Count() => _stack.Count;
    public List<PlantState> GetStack => _stack;
}

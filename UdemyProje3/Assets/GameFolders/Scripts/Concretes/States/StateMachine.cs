using System.Collections.Generic;
using UdemyProje3.Abstracts.States;
using UdemyProje3.States;

public class StateMachine
{
    List<StateTransformer> _stateTransformers = new List<StateTransformer>();
    List<StateTransformer> _anystateTransformers = new List<StateTransformer>();
    IState _currentState;
    public void SetState(IState state)
    {
        if (_currentState == state) return;
        _currentState?.OnExit();
        _currentState = state;
        _currentState.OnEnter();
    }
    //TODO
    //Tick içinde State deðiþimini kontrol edecek metod!
    public void Tick()
    {
        StateTransformer stateTransformer = CheckForTransformer();
        if (stateTransformer != null)
        {
            SetState(stateTransformer.To);
        }
        _currentState.Tick();
    }
    public void TickFixed()
    {
        _currentState.TickFixed();
    }

    private StateTransformer CheckForTransformer()
    {
        foreach (StateTransformer stateTransformer in _anystateTransformers)
        {
            if (stateTransformer.Condition.Invoke()) return stateTransformer;
        }
        foreach (StateTransformer stateTransformer1 in _stateTransformers)
        {
            if (stateTransformer1.Condition.Invoke() && _currentState == stateTransformer1.From) return stateTransformer1;
        }
        return null;
    }
    public void TickLate()
    {
        _currentState.TickLate();
    }

    public void AddState(IState from, IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(from, to, condition);
        _stateTransformers.Add(stateTransformer);
    }
    public void AddAnyState(IState to, System.Func<bool> condition)
    {
        StateTransformer anyStateTransformer = new StateTransformer(null, to, condition);
        _anystateTransformers.Add(anyStateTransformer);
    }
}



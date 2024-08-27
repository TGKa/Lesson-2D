using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorSkeleton : MonoBehaviour,ISwitchingState
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private TargetSearching _targetSearching;    

    private List<BaseState> _allStates;
    private BaseState _currentState;

    private void Awake()
    {
        _allStates = new List<BaseState>();
        GetComponents(_allStates);
    }

    private void Start()
    {
        InitAllState();
        _currentState = _allStates[0];
        _currentState.enabled = true;
    }

    public void SwitchState<T>() where T : BaseState
    {
        BaseState state = _allStates.FirstOrDefault(state => state is T);
        _currentState.enabled = false;
        _currentState = state;
        _currentState.enabled = true;
    }

    private void InitAllState()
    {
        foreach (var state in _allStates)
            state.Init(_enemy, _targetSearching, this);
    }
}

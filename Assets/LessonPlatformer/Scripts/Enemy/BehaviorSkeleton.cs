using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorSkeleton : MonoBehaviour,ISwitchingState
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private TargetSearching _targetSearching;    

    private List<BaseState> _allState;
    private BaseState _currentState;

    private void Awake()
    {
        _allState = new List<BaseState>();
        GetComponents(_allState);
    }

    private void Start()
    {
        InitAllState();
        _currentState = _allState[0];
        _currentState.enabled = true;
    }

    public void SwitchState<T>() where T : BaseState
    {
        BaseState state = _allState.FirstOrDefault(state => state is T);
        _currentState.enabled = false;
        _currentState = state;
        _currentState.enabled = true;
    }

    private void InitAllState()
    {
        foreach (var state in _allState)
            state.Init(_enemy, _targetSearching, this);
    }
}

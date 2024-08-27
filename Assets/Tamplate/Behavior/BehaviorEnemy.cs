using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BehaviorEnemy : MonoBehaviour, ISwitchingState
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SwitchingAnimation _switchingAnimation;

    private List<StateEnemy> _allState;
    private StateEnemy _currentState;

    private void Start()
    {
        CreateAllState();

        //_enemy.Health.Died += OnDied;
        _enemy.Health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        //_enemy.Health.Died -= OnDied;
        _enemy.Health.Changed -= OnChanged;
    }

    private void Update() =>
        _currentState.Update();

    public void SwitchState<T>() where T : BaseState //StateEnemy
    {
        StateEnemy state = _allState.FirstOrDefault(state => state is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.Start();
    }

    private void CreateAllState()
    {
        _allState = new List<StateEnemy>()
        {
            new PatrolEnemyState(_enemy,_switchingAnimation,this),
            new MoverToTargetState(_enemy,_switchingAnimation,this),
            new AttackState(_enemy,_switchingAnimation,this),
            new HitTackingState(_enemy,_switchingAnimation,this),
            new DeathState(_enemy,_switchingAnimation,this),
        };

        _currentState = _allState[0];
        _currentState.Start();
    }

    private void OnDied()
    {
        //SwitchState<DeathState>();
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnChanged(int value)
    {
        //SwitchState<HitTackingState>();
    }
}

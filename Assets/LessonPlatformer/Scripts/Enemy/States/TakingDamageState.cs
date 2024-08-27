using System.Collections;
using UnityEngine;

public class TakingDamageState : BaseState
{
    [SerializeField] private float _delayAnimation;
    [SerializeField] private Collider2D _collider;

    private int _health;
    private Enemy _enemy;
    private Coroutine _jobWait;
    private WaitForSeconds _delay;

    private void OnDestroy()=>
        _enemy.Health.Changed -= OnChanged;

    private void OnEnable()
    {
        if (_health > 0)
        {
            StartWait();
        }
        else
        {
            if (_jobWait != null)
                StopCoroutine(_jobWait);

            SwitchAnimation.StartDeathAnimation();
            _collider.enabled = false;
        }
    }

    public override void Init(Enemy enemy, TargetSearching targetSearching, ISwitchingState switchingState)
    {
        base.Init(enemy, targetSearching, switchingState);

        _delay = new WaitForSeconds(_delayAnimation);
        _enemy = enemy;
        _enemy.Health.Changed += OnChanged;
    }

    private void OnChanged(int value)
    {
        _health=value;
        SwitchingState.SwitchState<TakingDamageState>();
    }

    private void StartWait()
    {
        if (_jobWait != null)
            StopCoroutine(_jobWait);

        _jobWait = StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        SwitchAnimation.StartHitAnimation();

        yield return _delay;

        if (_health > 0)
        {
            if (TargetSearching.CanAttackTarget)
                SwitchingState.SwitchState<CombatState>();
            else
                SwitchingState.SwitchState<MovementToTargetState>();
        }
    }
}

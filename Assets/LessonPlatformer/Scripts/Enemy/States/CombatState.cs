using System.Collections;
using UnityEngine;

public class CombatState : BaseState
{
    [SerializeField]private float _velocityAnimation;

    private int _damage;
    private Coroutine _jobAttack;

    private void OnEnable() =>
        StartAttack();

    private void OnDisable()
    {
        if (_jobAttack != null)
            StopCoroutine(_jobAttack);
    }

    public override void Init(Enemy enemy, TargetSearching targetSearching, ISwitchingState switchingState)
    {
        base.Init(enemy, targetSearching, switchingState);

        _damage = enemy.Damage;
    }

    private void StartAttack()
    {
        if (_jobAttack != null)
            StopCoroutine(_jobAttack);

        _jobAttack = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        var _delay = new WaitForSeconds(_velocityAnimation / 2);
        SwitchAnimation.StartAttackBaseAnimation();

        yield return _delay;

        ApplyDamage();

        yield return _delay;

        SwitchState();
    }

    private void ApplyDamage()
    {
        Player target = TargetSearching.ToHitTarget();

        if (target != null)
            target.Health.TakeDamage(_damage);
    }

    private void SwitchState()
    {
        if (TargetSearching.CanAttackTarget)
            StartAttack();
        else
            SwitchingState.SwitchState<MovementToTargetState>();
    }
}

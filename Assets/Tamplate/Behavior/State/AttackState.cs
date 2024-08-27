using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateEnemy
{
    private Transform _enemy;
    private Transform _rayPoint;
    private int _damage;
    private float _impacktDistance;

    public AttackState(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState) 
        : base(enemy, switchingAnimation, switchingState)
    {
        _enemy = enemy.transform;
        //_rayPoint = enemy.RayPoint;
        //_damage = enemy.Damage;
    }

    public override void Start()
    {
        SwitchingAnimation.StartAttackBaseAnimation();
        SwitchingAnimation.StartCoroutine(Wait());
    }

    public override void Stop()
    {
    }

    public override void Update()
    {
        

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);

        if (DetectionTarget.TrySeeTarget(_rayPoint.position, _enemy.right, _impacktDistance))
            Target.Health.TakeDamage(_damage);

        yield return new WaitForSeconds(0.5f);

        if (DetectionTarget.TrySeeTarget(_rayPoint.position, _enemy.right, _impacktDistance))
            Start();
        //else 
        //    SwitchingState.SwitchState<MovementToTargetState>();
    }
}

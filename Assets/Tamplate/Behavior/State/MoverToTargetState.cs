using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverToTargetState : StateEnemy
{
    private Transform _enemy;
    private Transform _stoppingPosition;
    private Transform _rayPoint;
    private Rotator _rotator;
    private Coroutine _jobLoseTarget;
    private float _speed;
    private bool _isTargetSee;
    private float _delayLostTarget = 3f;
    private float _impacktDistance;
    private float _viewDistance;

    public MoverToTargetState(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState) 
        : base(enemy, switchingAnimation, switchingState)
    {
        _rotator = new Rotator();
        _speed = enemy.Speed;
        _enemy = enemy.transform;
        //_stoppingPosition = enemy.StoppingPosition;
        //_rayPoint = enemy.RayPoint;
    }

    public override void Start()
    {
        SwitchingAnimation.StartWalkAnimation();
    }

    public override void Stop() { }

    public override void Update()
    {
        if (TryTakeStep(Target.transform.position.x))
            Move();

        SwitchState();
    }

    private void StartLoseTarget()
    {
        if (_jobLoseTarget != null)
            return;

        _jobLoseTarget = SwitchingAnimation.StartCoroutine(LoseTarget());
    }

    private IEnumerator LoseTarget()
    {
        yield return new WaitForSeconds(_delayLostTarget);

        _jobLoseTarget = null;

        //if (_isTargetSee == false)
        //    SwitchingState.SwitchState<PatrolState>();
    }

    private void Move()
    {
        _enemy.eulerAngles = _rotator.LookAt(_enemy.position.x < Target.transform.position.x);
        _enemy.Translate(_enemy.right * _speed * Time.deltaTime, Space.World);
    }

    private bool TryTakeStep(float targetPositionX)
    {
        float deviation = 0.1f;
        Vector2 position = new Vector2(targetPositionX - deviation, targetPositionX + deviation);

        float value = Mathf.Clamp(_enemy.position.x, position.x, position.y);

        return position.x == value || position.y == value ? true : false;
    }

    private void SwitchState()
    {
        _isTargetSee = DetectionTarget.IsTargetSee(_enemy, Target.transform.position, _viewDistance);
        bool canAttack = DetectionTarget.TrySeeTarget(_rayPoint.position, _enemy.right, _impacktDistance);

        //if (canAttack)
        //    SwitchingState.SwitchState<AttackState>();

        if (_isTargetSee == false)
            StartLoseTarget();
    }
}

using UnityEngine;

public class MovementToTargetState : BaseState
{
    [SerializeField] private Transform _stopPosition;

    private Transform _target;
    private Transform _enemy;
    private Rotator _rotator;
    private float _speed;

    private void Start() =>
        _rotator = new Rotator();

    private void OnEnable() =>
        SwitchAnimation.StartWalkAnimation();

    private void Update()
    {
        if (TargetSearching.IsTargetSee)
        {
            Move();

            if (TargetSearching.CanAttackTarget)
                SwitchingState.SwitchState<CombatState>();
        }
        else
        {
            SwitchingState.SwitchState<PatrolState>();
        }
    }

    public override void Init(Enemy enemy, TargetSearching targetSearching, ISwitchingState switchingState)
    {
        base.Init(enemy, targetSearching, switchingState);

        _enemy = enemy.transform;
        _speed = enemy.Speed;
        _target = targetSearching.GetTargetTarnsform();
    }

    private void Move()
    {
        if (TryTakeStep(_target.position.x) && TryTakeStep(_stopPosition.position.x))
        {
            _enemy.eulerAngles = _rotator.LookAt(_enemy.position.x < _target.position.x);
            _enemy.Translate(_enemy.right * _speed * Time.deltaTime, Space.World);
        }
    }

    private bool TryTakeStep(float targetPositionX)
    {
        float deviation = 0.1f;
        Vector2 position = new Vector2(targetPositionX - deviation, targetPositionX + deviation);

        float value = Mathf.Clamp(_enemy.position.x, position.x, position.y);

        return position.x == value || position.y == value;
    }
}

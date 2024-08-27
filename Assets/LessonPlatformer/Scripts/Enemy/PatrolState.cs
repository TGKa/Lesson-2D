using UnityEngine;

public class PatrolState : BaseState
{
    
    [SerializeField] private Transform[] _patrolPath;

    private Transform _enemy;
    private Rotator _rotator;
    private float _speed;
    private int _currentPoint = 0;

    private void Start() =>
        _rotator = new Rotator();

    private void OnEnable()
    {
        SwitchAnimation.StartWalkAnimation();
    }

    private void Update()
    {
        if (TargetSearching.IsTargetSee == false)
            Move();
        else
            SwitchingState.SwitchState<MovementToTargetState>();
    }

    public override void Init(Enemy enemy, TargetSearching targetSearching, ISwitchingState switchingState)
    {
        base.Init(enemy, targetSearching, switchingState);

        _speed = enemy.Speed;
        _enemy = enemy.transform;
    }

    private void Move()
    {
        if (_enemy.position == _patrolPath[_currentPoint].position)
            _currentPoint = ++_currentPoint % _patrolPath.Length;

        Vector2 nextPosition = Vector2.MoveTowards(_enemy.position, _patrolPath[_currentPoint].position, _speed * Time.deltaTime);
        _enemy.position = nextPosition;

        _enemy.eulerAngles = _rotator.LookAt(_enemy.position.x < _patrolPath[_currentPoint].position.x);
    }
}

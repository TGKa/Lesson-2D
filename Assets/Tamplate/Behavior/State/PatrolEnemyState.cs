using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyState : StateEnemy
{
    private Transform _enemy;
    private Transform[] _path;
    private Transform _rayPoint;
    private Rotator _rotator;
    private float _speed;
    private int _currentPoint = 0;
    private float _viewDistance;

    public PatrolEnemyState(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState)
        : base(enemy, switchingAnimation, switchingState) 
    {
        _rotator = new Rotator();
        _speed = enemy.Speed;
        _enemy = enemy.transform;
        //_rayPoint = enemy.RayPoint;
        //_path = new Transform[enemy.CountPointPath];

        //for (int i = 0; i < enemy.CountPointPath; i++)
        //    _path[i] = enemy.GetPointPath(i);
    }

    public override void Start() =>
        SwitchingAnimation.StartWalkAnimation();

    public override void Stop() { }

    public override void Update()
    {
        if (_enemy.position == _path[_currentPoint].position)
            _currentPoint = ++_currentPoint % _path.Length;
        
        Move();

        //if (DetectionTarget.TrySeeTarget(_rayPoint.position, _enemy.right, _viewDistance))
        //    SwitchingState.SwitchState<MovementToTargetState>();
    }

    private void Move()
    {
        Vector2 nextPosition = Vector2.MoveTowards(_enemy.position, _path[_currentPoint].position, _speed * Time.deltaTime);
        _enemy.position = nextPosition;

        _enemy.eulerAngles = _rotator.LookAt(_enemy.position.x < _path[_currentPoint].position.x);
    }
}

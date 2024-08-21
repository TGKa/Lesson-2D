using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _path;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;
    private Rotator _rotator;

    private void Awake() =>
        _rotator = new Rotator();

    private void Update()
    {
        if (transform.position == _path[_currentPoint].position)
            _currentPoint = ++_currentPoint % _path.Length;

        Vector2 nextPosition = Vector2.MoveTowards(transform.position, _path[_currentPoint].position, _speed * Time.deltaTime);
        transform.position = nextPosition;

        transform.eulerAngles = _rotator.LookAt(transform.position.x < _path[_currentPoint].position.x);
    }
}

using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _path;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;

    private void Update()
    {
        if (transform.position == _path[_currentPoint].position)
            _currentPoint = (_currentPoint + 1) % _path.Length;

        Vector2 direction = Vector2.MoveTowards(transform.position, _path[_currentPoint].position, _speed * Time.deltaTime);
        transform.position = direction;
        LookAt();
    }

    private void LookAt()
    {
        if (transform.position.x < _path[_currentPoint].position.x)
            transform.eulerAngles = new Vector2(0f, 0f);
        else
            transform.eulerAngles = new Vector2(0f, 180f);
    }
}

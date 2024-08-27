using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _layerMovement;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SwitchingAnimation _animator;
    [SerializeField] private Attacker _attackign;

    private Rigidbody2D _rigibody;
    private Rotator _rotator;
    private InputReader _inputReader;
    private bool _isGround = true;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _rotator = new Rotator();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerMovement)
            _isGround = true;
    }
    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0 && _attackign.CanAttack)
            Move(_inputReader.Direction);

        else if (_isGround && _attackign.CanAttack)
            _animator.StartIdleAnimation();

        if (_inputReader.GetIsJump && _isGround && _attackign.CanAttack)
            Jump();
    }

    private void Move(float direction)
    {
        if (_isGround)
            _animator.StartRunAnimation();

        _rigibody.velocity = new Vector2(direction * _speed, _rigibody.velocity.y);

        transform.eulerAngles = _rotator.LookAt(direction > 0);
    }

    private void Jump()
    {
        _rigibody.velocity = new Vector2(_rigibody.velocity.x, 0f);
        _rigibody.AddForce(Vector2.up * _jumpForce);
        _animator.StartJumpAnimation();
        _isGround = false;
    }
}

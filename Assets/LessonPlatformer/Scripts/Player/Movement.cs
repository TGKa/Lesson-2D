using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private int _layerMovement;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigibody;
    private bool _isJumping = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerMovement)
            _isJumping = false;
    }
    private void Update()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        if (direction != 0)
            Move(direction);
        else if (_isJumping==false)
            _animator.CrossFade("Idle", 0f);

        Jump();
    }

    private void Move(float direction)
    {
        if (_isJumping == false)
            _animator.CrossFade("Run", 0f);

        _rigibody.velocity = new Vector2(Input.GetAxis(Horizontal) * _speed, _rigibody.velocity.y);

        if (direction > 0)
            SetRotation(true);
        else
            SetRotation(false);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _rigibody.AddForce(Vector2.up * _jumpForce);
            _animator.CrossFade("Jump", 0f);
            _isJumping = true;
        }
    }

    private void SetRotation(bool isRight)
    {
        if (isRight)
            transform.eulerAngles = new Vector2(0f, 0f);
        else
            transform.eulerAngles = new Vector2(0f, 180f);
    }
}

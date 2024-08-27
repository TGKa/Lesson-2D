using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _direction;
    private bool _isJumping = false;
    private bool _isAttack = false;

    public float Direction => _direction;
    public bool GetIsJump => GetBoolIsTrigger(ref _isJumping);
    public bool GetIsAttack => GetBoolIsTrigger(ref _isAttack);

    private void Update()
    {
        _direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
            _isJumping = true;

        if (Input.GetMouseButtonDown(0))
            _isAttack = true;
    }

    private bool GetBoolIsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}

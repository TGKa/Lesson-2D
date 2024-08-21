using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private float _direction;
    private bool _isJumping = false;

    public float Direction => _direction;
    public bool GetIsJump => GetBoolIsTrigger();

    private void Update()
    {
        _direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
            _isJumping = true;
    }

    private bool GetBoolIsTrigger()
    {
        bool value = _isJumping;
        _isJumping = false;
        return value;
    }
}

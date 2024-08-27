using UnityEngine;
using System;

public class Health
{
    private readonly int _maxHealth;
    private int _value;

    public event Action<int> Changed;

    public int Count => _value;

    public Health(int health)
    {
        _maxHealth = health;
        _value = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        ChangeValue(-damage);
    }

    public void Heal(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        ChangeValue(value);
    }

    private void ChangeValue(int value)
    {
        _value += value;
        _value = Mathf.Clamp(_value, 0, _maxHealth);

        Changed?.Invoke(_value);
    }
}

using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startingHealth;

    private int money;
    private Health _health;

    public event Action<int> MoneyChanged;

    public Health Health => _health;

    private void Awake() =>
        _health = new Health(_startingHealth);

    public void AddMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        money += count;
        MoneyChanged?.Invoke(money);
    }
}

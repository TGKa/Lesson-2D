using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private int money;

    public event Action<int> MoneyChanged;

    public void AddMoney(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        money += count;
        MoneyChanged?.Invoke(money);
    }
}

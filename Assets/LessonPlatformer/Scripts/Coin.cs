using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _value = 1;

    public event Action Destroying;

    public int Value => _value;

    public void Destroy()
    {
        Destroying?.Invoke();
        Destroy(gameObject);
    }
}

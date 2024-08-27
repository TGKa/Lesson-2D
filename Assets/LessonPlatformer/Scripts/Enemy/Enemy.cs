using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Min(1)] private int _startingHealth;

    private Health _health;

    public Health Health => _health;

    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }

    private void Awake() =>
        _health = new Health(_startingHealth);
}

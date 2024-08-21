using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private List<Transform> _points;

    private int _currentIndex = 0;
    private Coin _currentCoin;

    private void Start() =>
        Spawn();

    private void OnDisable()
    {
        if (_currentCoin != null)
            _currentCoin.Destroying -= OnDestroying;
    }

    private void Spawn()
    {
        if (_currentIndex < _points.Count)
        {
            _currentCoin = Instantiate(_prefab, _points[_currentIndex].position, _points[_currentIndex].rotation);
            _currentCoin.Destroying += OnDestroying;
            _currentIndex++;
        }
    }

    private void OnDestroying()
    {
        _currentCoin.Destroying -= OnDestroying;
        Spawn();
    }
}

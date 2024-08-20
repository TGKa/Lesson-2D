using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private List<Transform> _points;

    private void Start() =>
        Spawn();

    private void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
            Instantiate(_prefab, _points[i].position, _points[i].rotation, _container);
    }
}

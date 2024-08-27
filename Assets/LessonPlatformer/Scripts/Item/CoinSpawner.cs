using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform _contair;
    [SerializeField] private List<Transform> _points;

    private void Start() =>
        Spawn();

    private void Spawn()
    {
        for (int i = 0; i < _points.Count; i++)
            Instantiate(_prefab, _points[i].position, _points[i].rotation,_contair);
    }
}

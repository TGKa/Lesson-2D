using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ItemTake : MonoBehaviour
{
    private Player _player;

    private void Start() =>
        _player = GetComponent<Player>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _player.AddMoney(coin.Value);
            coin.Destroy();
        }
    }
}

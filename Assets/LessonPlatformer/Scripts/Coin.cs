using UnityEngine;

public class Coin : MonoBehaviour
{
    private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.AddMoney(value);
            Destroy(gameObject);
        }
    }
}

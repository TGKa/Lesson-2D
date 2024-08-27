using UnityEngine;

public class ItemTake : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _player.AddMoney(coin.Value);
            Destroy(coin.gameObject);
        }
        else if(collision.TryGetComponent<MedicalKit>(out MedicalKit kit))
        {
            _player.Health.Heal(kit.Value);
            Destroy(kit.gameObject);
        }
    }
}

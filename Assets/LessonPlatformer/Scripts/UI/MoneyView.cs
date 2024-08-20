using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _money;

    private void OnEnable() =>
        _player.MoneyChanged += OnMoneyChanged;

    private void OnDisable() =>
        _player.MoneyChanged -= OnMoneyChanged;

    private void OnMoneyChanged(int value)
    {
        _money.text = value.ToString();
    }
}

public class MoneyView : TextView
{
    private void OnEnable() =>
        Player.MoneyChanged += ChangeText;

    private void OnDisable() =>
        Player.MoneyChanged -= ChangeText;
}

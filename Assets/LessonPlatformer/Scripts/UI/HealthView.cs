public class HealthView : TextView
{
    private void Start()
    {
        Player.Health.Changed += ChangeText;
        ChangeText(Player.Health.Count);
    }

    private void OnDisable()=>
        Player.Health.Changed -= ChangeText;

    protected override void ChangeText(int value)=>
        Text.text = $"Health : {value}";
}

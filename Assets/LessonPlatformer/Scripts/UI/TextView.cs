using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] protected TMP_Text Text;

    protected virtual void ChangeText(int value) =>
        Text.text = value.ToString();
}

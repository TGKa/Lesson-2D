using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected TargetSearching TargetSearching;
    protected ISwitchingState SwitchingState;    
    protected BaseSwitchAnimation SwitchAnimation;

    private void Awake()
    {
        SwitchAnimation = GetComponentInParent<BaseSwitchAnimation>();
        enabled = false;
    }

    public virtual void Init(Enemy enemy, TargetSearching targetSearching, ISwitchingState switchingState)
    {
        TargetSearching = targetSearching;
        SwitchingState = switchingState;
    }
}

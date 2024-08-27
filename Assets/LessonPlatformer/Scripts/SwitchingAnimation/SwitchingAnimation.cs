using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitchingAnimation : BaseSwitchAnimation
{
    public void StartRunAnimation() =>
        Animator.CrossFade(NameHash.RunHash, 0f);

    public void StartJumpAnimation()=>
        Animator.CrossFade(NameHash.JumpHash, 0f);
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseSwitchAnimation : MonoBehaviour
{
    protected Animator Animator;
    protected NameHashAnimation NameHash;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        NameHash = new NameHashAnimation();
    }

    public void StartIdleAnimation() =>
        Animator.CrossFade(NameHash.IdleHash, 0f);

    public void StartWalkAnimation() =>
        Animator.CrossFade(NameHash.WalkHash, 0f);

    public void StartAttackBaseAnimation() =>
        Animator.CrossFade(NameHash.AttackBase, 0f);

    public void StartHitAnimation() =>
        Animator.CrossFade(NameHash.HitHash, 0f);

    public void StartDeathAnimation() =>
        Animator.CrossFade(NameHash.DeathHash, 0f);
}

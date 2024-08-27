using UnityEngine;

public class NameHashAnimation
{
    public readonly int IdleHash = Animator.StringToHash("Idle");
    public readonly int RunHash = Animator.StringToHash("Run");
    public readonly int JumpHash = Animator.StringToHash("Jump");
    public readonly int AttackBase = Animator.StringToHash("AttackBase");
    public readonly int DeathHash = Animator.StringToHash("Death");
    public readonly int HitHash = Animator.StringToHash("Hit");
    public readonly int WalkHash = Animator.StringToHash("Walk");
}

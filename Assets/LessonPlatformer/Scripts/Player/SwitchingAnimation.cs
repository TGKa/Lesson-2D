using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitchingAnimation : MonoBehaviour
{
    private readonly int IdleHash = Animator.StringToHash("Idle");
    private readonly int RunHash = Animator.StringToHash("Run");
    private readonly int JumpHash = Animator.StringToHash("Jump");

    private Animator _animator;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    public void StartIdleAnimation() =>
        _animator.CrossFade(IdleHash, 0f);

    public void StartRunAnimation() =>
        _animator.CrossFade(RunHash, 0f);

    public void StartJumpAnimation()=>
        _animator.CrossFade(JumpHash, 0f);
}

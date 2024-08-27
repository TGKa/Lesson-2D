using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTackingState : StateEnemy
{
    private float _delay = 1f;
    private Coroutine _jobWait;

    public HitTackingState(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState) 
        : base(enemy, switchingAnimation, switchingState) { }

    public override void Start()
    {
        SwitchingAnimation.StartHitAnimation();
        _jobWait = SwitchingAnimation.StartCoroutine(Wait());
    }

    public override void Stop()
    {
        if (_jobWait != null)
            SwitchingAnimation.StopCoroutine(_jobWait);
    }

    public override void Update() { }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_delay);

        //SwitchingState.SwitchState<MovementToTargetState>();
    }
}

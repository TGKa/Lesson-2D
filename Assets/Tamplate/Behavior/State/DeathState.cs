using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : StateEnemy
{
    public DeathState(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState) 
        : base(enemy, switchingAnimation, switchingState) { }

    public override void Start() =>
        SwitchingAnimation.StartDeathAnimation();

    public override void Stop() { }

    public override void Update() { }
}

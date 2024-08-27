public abstract class StateEnemy
{
    protected Player Target;
    protected SwitchingAnimation SwitchingAnimation;
    protected ISwitchingState SwitchingState;
    protected DetectionTargetHelper DetectionTarget;

    public StateEnemy(Enemy enemy, SwitchingAnimation switchingAnimation, ISwitchingState switchingState)
    {
        //Target = enemy.Target;
        SwitchingAnimation = switchingAnimation;
        SwitchingState = switchingState;
        DetectionTarget = new DetectionTargetHelper();
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Update();
}

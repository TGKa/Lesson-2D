public interface ISwitchingState
{
    public void SwitchState<T>() where T : BaseState;
}

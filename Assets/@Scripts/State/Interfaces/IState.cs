namespace SpinProject.State
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}

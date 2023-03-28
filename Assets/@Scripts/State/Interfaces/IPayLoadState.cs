namespace SpinPtoject.State
{
    public interface IPayLoadState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}

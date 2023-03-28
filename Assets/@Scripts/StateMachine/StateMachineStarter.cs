using SpinPtoject.Service;
using SpinPtoject.Structure;

namespace SpinPtoject.StateMachine
{
    public class StateMachineStarter
    {
        public GameStateMachine StateMachine;

        public StateMachineStarter(ICoroutineRunner coroutineRunner, LoadingUI loadingUi)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingUi, AllServices.Container);
        }
    }
}
using SpinPtoject.Service;
using SpinPtoject.StateMachine;
using SpinPtoject.Structure;

namespace SpinPtoject.State
{
    public class BootstrapState : IState
    {
        private const string INITIAL_SCENE = "Initial";

        private readonly AllServices _services;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _services = services;
            _sceneLoader = sceneLoader;
            _stateMachine = gameStateMachine;

            GloabalRegisterService();
        }


        public void Enter() => _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);

        private void GloabalRegisterService()
        {
        }

        public void Exit() { }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();
    }
}

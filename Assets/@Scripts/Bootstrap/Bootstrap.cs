using SpinProject.State;
using SpinProject.StateMachine;
using UnityEngine;

namespace SpinProject.Structure
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        public LoadingUI LoadingUI;

        private StateMachineStarter _game;

        private void Awake()
        {
            _game = new StateMachineStarter(this, Instantiate(LoadingUI));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
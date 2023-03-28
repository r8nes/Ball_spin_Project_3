using SpinPtoject.State;
using SpinPtoject.StateMachine;
using UnityEngine;

namespace SpinPtoject.Structure
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
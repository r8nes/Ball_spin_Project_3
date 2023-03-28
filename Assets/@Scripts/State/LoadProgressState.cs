using SpinPtoject.StateMachine;
using UnityEngine;

namespace SpinPtoject.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() => LoadProgressOrInitNew();

        public void Exit() { }

        private void LoadProgressOrInitNew() => Debug.Log("Load");
    }
}
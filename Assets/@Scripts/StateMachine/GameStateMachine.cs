using System;
using System.Collections.Generic;
using SpinProject.Service;
using SpinProject.State;
using SpinProject.Structure;

namespace SpinProject.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IExitableState _activeState;

        private readonly Dictionary<Type, IExitableState> _states;

        public GameStateMachine(SceneLoader sceneLoader, LoadingUI loadingUi, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                this,
                sceneLoader,
                services),
            };
        }

        #region State Methods

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState :
            class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState :
            class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;

        #endregion
    }
}
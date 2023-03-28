﻿using SpinProject.Service;
using SpinProject.StateMachine;
using UnityEngine;

namespace SpinProject.State
{
    public partial class LoadProgressState : IState
    {
        private const string START_SCENE = "Menu";

        private readonly GameStateMachine _gameStateMachine;

        //private readonly IProgressService _progressService;
        //private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() => LoadProgressOrInitNew();

        public void Exit() { }

        private void LoadProgressOrInitNew() => Debug.Log("Load");
    }
}
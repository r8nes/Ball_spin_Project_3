using System;
using SpinProject.Data;
using SpinProject.Factory;
using SpinProject.Service;
using SpinProject.StateMachine;
using SpinProject.Structure;
using UnityEngine;

namespace SpinProject.State
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IProgressService _progressService;

        private readonly LoadingUI _loadingUI;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI,
            IGameFactory gameFactory, IStaticDataService dataService, IProgressService progressService, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _loadingUI = loadingUI;
            _dataService = dataService;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(string sceneName)
        {
            _loadingUI.HideLoader();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoadedLevels);
        }

        public void Exit()
        {
            _loadingUI.ShowLoader();
        }

        private void OnLoadedLevels()
        {
            InitUIRoot();
            InitLevelsPanel();
            InformProgressReaders();
        }

        private LevelStaticData GetLevelStaticData(int levelIndex)
        {
            LevelStaticData levelData = _dataService.ForLevel(levelIndex);
            return levelData;
        }

        #region Initials
        private GameObject InitUIRoot()
        {
            GameObject root = _uiFactory.CreateUIRoot();
            return root;
        }

        private void InitGameWrold(int level)
        {
            LevelStaticData levelData = GetLevelStaticData(level);

            InitHud();
        }

        private GameObject InitHud()
        {
            GameObject hud = _gameFactory.CreateHud();
            return hud;
        }

        private void StartNewLevel() 
        {
            _sceneLoader.Load("Main", Exit);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitLevelsPanel() 
        {
            var panel = _uiFactory.AddLevelPanel();
            _uiFactory.AddLevelButtons(panel.transform, StartNewLevel);
        }

        private GameObject InitPlayer(LevelStaticData levelData)
        {
            return _gameFactory.CreatePlayer(levelData.InitialHeroPosition);
        }

        #endregion


        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReader)
                reader.LoadProgress(_progressService.Progress);
        }
    }
}
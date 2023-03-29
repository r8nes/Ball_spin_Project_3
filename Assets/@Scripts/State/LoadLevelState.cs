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
            _gameFactory.Cleanup();
            OnLoaded();
           // _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingUI.ShowLoader();
        }

        private void OnLoaded()
        {
            InitUIRoot();
            //InitGameWrold();
            InformProgressReaders();
        }

        private LevelStaticData GetLevelStaticData(int levelIndex)
        {

            LevelStaticData levelData = _dataService.ForLevel(levelIndex);
            return levelData;
        }

        #region Initials
        private void InitUIRoot()
        {
            _uiFactory.CreateUIRoot();
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

        private GameObject InitPlayer(LevelStaticData levelData) => _gameFactory.CreatePlayer(levelData.InitialHeroPosition);

        #endregion

  
        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReader)
                reader.LoadProgress(_progressService.Progress);
        }
    }
}
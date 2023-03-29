using System.Collections.Generic;
using SpinProject.Data;
using SpinProject.Service;
using UnityEngine;

namespace SpinProject.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assets;
        private readonly IWindowService _windowService;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private GameObject PlayerGameObject { get; set; }

        public GameFactory(IAssetsProvider assets, IProgressService progressService, IStaticDataService staticData, IWindowService windowService)
        {
            _assets = assets;
            _progressService = progressService;
            _staticData = staticData;
            _windowService = windowService;
        }

        public List<ISavedProgress> ProgressWriters => new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReader => new List<ISavedProgressReader>();

        public void Cleanup()
        {
            ProgressReader.Clear();
            ProgressWriters.Clear();

            ProgressReader.Capacity = 10;
            ProgressWriters.Capacity = 10;
        }

        public void Register(ISavedProgressReader reader)
        {
            if (reader is ISavedProgress writer)
                ProgressWriters.Add(writer);

            ProgressReader.Add(reader);
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponents<ISavedProgressReader>())
                Register(progressReader);
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector2 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        public GameObject CreateHud()
        {
            GameObject hud = InstantiateRegistered(AssetsPath.GLOBAL_HUD_PATH);

            foreach (OpenWindowButton window in hud.GetComponentsInChildren<OpenWindowButton>())
                window.Construct(_windowService);

            return hud;
        }

        public GameObject CreatePlayer(Vector2 initialPoint)
        {
            PlayerGameObject = InstantiateRegistered(AssetsPath.PLAYER_PATH, initialPoint);

            return PlayerGameObject;
        }
    }
}
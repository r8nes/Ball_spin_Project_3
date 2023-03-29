using System.Collections.Generic;
using SpinProject.Data;
using SpinProject.Service;
using UnityEngine;
using UnityEngine.UI;

namespace SpinProject.Factory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;

        private readonly IAssetsProvider _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private readonly IGameStateMachine _stateMachine;

        private readonly List<WindowBase> OpenWindows = new List<WindowBase>(4);

        public UIFactory(IAssetsProvider asset, IStaticDataService staticData, IProgressService progressService, IGameStateMachine stateMachine)
        {
            _asset = asset;
            _staticData = staticData;
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public GameObject CreateUIRoot()
        {
            GameObject root = _asset.Instantiate(AssetsPath.GLOBAL_HUD_PATH);
            _uiRoot = root.transform;

            return root;
        }

        public void AddLevelPanel(Transform root)
        {
            GameObject panel = _asset.Instantiate(AssetsPath.BUTTON_HUD_PATH);
            panel.transform.SetParent(root);

            AddLevelsButtons(panel.transform);
        }

        public void CreateWindowById(WindowId windowId)
        {
            foreach (WindowBase openWindow in OpenWindows)
            {
                WindowId id = openWindow.GetId();
                if (id == windowId) return;
            }

            WindowConfigData config = _staticData.ForWindow(windowId);
            WindowBase window = UnityEngine.Object.Instantiate(config.Prefab, _uiRoot);

            window.Construct(windowId, _progressService, _stateMachine);
            window.WindowClosed += OnWindowClosed;

            OpenWindows.Add(window);
        }

        private void OnWindowClosed(WindowId id)
        {
            for (int i = 0; i < OpenWindows.Count; i++)
            {
                if (OpenWindows[i].GetId() == id)
                {
                    OpenWindows[i].WindowClosed -= OnWindowClosed;
                    OpenWindows.Remove(OpenWindows[i]);
                }
            }
        }

        private void AddLevelsButtons(Transform parent)
        {
            LevelsData levelsData = new LevelsData();
            var levelsProgress = levelsData.GetLevelsProgress();

            for (int i = 0; i < levelsProgress.Levels.Count; i++)
            {
                GameObject button = _asset.Instantiate(AssetsPath.LEVEL_BUTTON_PATH);
                button.transform.SetParent(parent);

                if (button.gameObject.TryGetComponent(out LevelButton buttonLevel))
                {
                    buttonLevel.SetData(levelsProgress.Levels[i], i);
                }
            }
        }
    }
}
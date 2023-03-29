using System;
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

        public GameObject AddLevelPanel()
        {
            GameObject panel = _asset.Instantiate(AssetsPath.BUTTON_HUD_PATH);
            
            if (_uiRoot != null)
            {
                panel.transform.SetParent(_uiRoot);
                panel.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            }
            else
            {
                throw new Exception($"No root. Root is {_uiRoot}");
            }

            return panel;
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

        public void AddLevelButtons(Transform parent, Action action)
        {
            LevelsData levelsData = new LevelsData();
            var levelsProgress = levelsData.GetLevelsProgress();

            for (int i = 0; i < levelsProgress.Levels.Count; i++)
            {
                GameObject button = _asset.Instantiate(AssetsPath.LEVEL_BUTTON_PATH);
                button.transform.SetParent(parent);

                if (button.TryGetComponent(out LevelButton buttonLevel))
                {
                    buttonLevel.SetData(levelsProgress.Levels[i], i);
                    buttonLevel.OnLevelChoosed += action;
                }
            }
        }
    }
}
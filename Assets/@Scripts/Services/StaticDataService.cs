using System.Collections.Generic;
using System.Linq;
using SpinProject.Data;
using UnityEngine;

namespace SpinProject.Service
{
    public class StaticDataService : IStaticDataService
    {
        private const string LEVELS_PATH = "Data/Levels";
        private const string WINDOWS_PATH = "Data/Windows/WindowData";

        private Dictionary<int, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowConfigData> _windowConfigs;

        public void Load()
        {
            _levels = Resources.LoadAll<LevelStaticData>(LEVELS_PATH)
                .ToDictionary(x => x.LevelKey, x => x);
            _windowConfigs = Resources.Load<WindowsStaticData>(WINDOWS_PATH).Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public LevelStaticData ForLevel(int levelIndex) =>
            _levels.TryGetValue(levelIndex, out LevelStaticData data)
            ? data
            : null;

        public WindowConfigData ForWindow(WindowId windowId) =>
           _windowConfigs.TryGetValue(windowId, out WindowConfigData data)
         ? data
         : null;
    }
}
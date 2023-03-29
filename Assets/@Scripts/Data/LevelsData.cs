using SpinProject.Service;
using UnityEngine;

namespace SpinProject.Data
{
    public class LevelsData : ISaveLoadService
    {
        private const string KeyName = "Save";
        private PlayerProgress _levelsProgress = new PlayerProgress();

        public void NewData()
        {
            var levelsCount = Resources.LoadAll<GameLevelData>("Data/Levels").Length;

            for (int i = 0; i < levelsCount; i++)
            {
                _levelsProgress.Levels.Add(new Progress());
            }
            _levelsProgress.Levels[0].IsOpened = true;

            SaveProgress();
            Resources.UnloadUnusedAssets();
        }

        public PlayerProgress GetLevelsProgress()
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                string saveJson = PlayerPrefs.GetString(KeyName);
                _levelsProgress = JsonUtility.FromJson<PlayerProgress>(saveJson);
            }
            else
            {
                NewData();
            }

            return _levelsProgress;
        }

        public void SaveLevelData(int index, Progress progress)
        {
            _levelsProgress = GetLevelsProgress();
            _levelsProgress.Levels[index] = progress;

            if (index < _levelsProgress.Levels.Count - 1)
            {
                _levelsProgress.Levels[index + 1].IsOpened = true;
            }

            SaveProgress();
        }

        public void SaveProgress()
        {
            string saveJson = JsonUtility.ToJson(_levelsProgress);

            PlayerPrefs.SetString(KeyName, saveJson);
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress()
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                string saveJson = PlayerPrefs.GetString(KeyName);
                _levelsProgress = JsonUtility.FromJson<PlayerProgress>(saveJson);
            }
            else
            {
                NewData();
            }

            return _levelsProgress;
        }
        public void Clear() => PlayerPrefs.DeleteKey(KeyName);
    }
}
using SpinProject.Data;
using SpinProject.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpinProject.Factory
{
    public class LevelButton : MonoBehaviour
    {
        private int _index;

        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public void SetData(LevelInfo progress, int index)
        {
            _buttonText.text = (index + 1).ToString();
            _index = index;
            _button.interactable = progress.IsOpened;
        }

        public void LevelSelected()
        {
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.SetIndex(_index);
        }
    }
}
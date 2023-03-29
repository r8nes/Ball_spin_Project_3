using SpinProject.Service;
using UnityEngine;
using UnityEngine.UI;

namespace SpinProject.Data
{
    public class OpenWindowButton : MonoBehaviour
    {
        public Button Button;
        public WindowId WindowId;

        private IWindowService _windowService;

        public void Construct(IWindowService windowService) => _windowService = windowService;

        private void Awake() => Button.onClick.AddListener(Open);

        private void Open() => _windowService.Open(WindowId);
    }
}
using System;
using SpinProject.Data;
using SpinProject.Service;
using UnityEngine;
using UnityEngine.UI;

namespace SpinProject.Factory
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;

        protected WindowId _windowId;

        protected IProgressService _progressService;
        protected IGameStateMachine _stateMachine;

        public event Action<WindowId> WindowClosed;

        protected PlayerProgress Progress => _progressService.Progress;

        public void Construct(WindowId Id, IProgressService progressService, IGameStateMachine stateMachine)
        {
            _windowId = Id;
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public WindowId GetId() => _windowId;

        private void Awake() => OnAwake();

        private void Start()
        {
            Initialize();
            SubScribeUpdates();
        }

        private void OnDestroy() => WindowClosed?.Invoke(_windowId);
        protected virtual void OnAwake() => CloseButton.onClick.AddListener(() => Destroy(gameObject));
        protected virtual void Initialize() { }
        protected virtual void SubScribeUpdates() { }
        protected virtual void CleanUp() { }
    }
}
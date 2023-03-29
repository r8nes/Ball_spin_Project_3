using SpinProject.Service;
using SpinProject.StateMachine;

namespace SpinProject.State
{
    public partial class LoadProgressState : IState
    {
        private const string LEVEL_SCENE = "Levels";

        private readonly GameStateMachine _gameStateMachine;

        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService, IProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(LEVEL_SCENE);
        }

        public void Exit() { }

        private void LoadProgressOrInitNew() =>
          _progressService.Progress =
          _saveLoadService.LoadProgress()
          ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            return progress;
        }
    }
}
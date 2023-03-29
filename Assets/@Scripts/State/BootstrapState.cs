using SpinProject.Data;
using SpinProject.Factory;
using SpinProject.Service;
using SpinProject.StateMachine;
using SpinProject.Structure;

namespace SpinProject.State
{
    public class BootstrapState : IState
    {
        private const string INITIAL_SCENE = "Init";

        private readonly AllServices _services;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _services = services;
            _sceneLoader = sceneLoader;
            _stateMachine = gameStateMachine;

            GloabalRegisterService();
        }

        public void Enter() => _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);

        public void Exit() { }

        private void GloabalRegisterService()
        {
            RegisterStateMachine();
            RegisterAssetProvider();
            RegisterStaticData();
            RegisterProgressService();
            RegisterUiFactory();
            RegisterWindowService();
            RegisterGameFactory();
            RegisterSaveLoadService();
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();

        private void RegisterStateMachine()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
        }

        private void RegisterAssetProvider()
        {
            var assetProvider = new AssetsProvider();
            _services.RegisterSingle<IAssetsProvider>(assetProvider);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private void RegisterProgressService()
        {
            _services.RegisterSingle<IProgressService>(new ProgressService());
        }

        private void RegisterUiFactory()
        {
            _services.RegisterSingle<IUIFactory>(
           new UIFactory(
           _services.Single<IAssetsProvider>(),
           _services.Single<IStaticDataService>(),
           _services.Single<IProgressService>(),
           _services.Single<IGameStateMachine>()
           ));
        }

        private void RegisterWindowService()
        {
            _services.RegisterSingle<IWindowService>(
               new WindowServices(
            _services.Single<IUIFactory>()
            ));
        }

        private void RegisterGameFactory()
        {
            _services.RegisterSingle<IGameFactory>(
                            new GameFactory(
                            _services.Single<IAssetsProvider>(),
                            _services.Single<IProgressService>(),
                            _services.Single<IStaticDataService>(),
                            _services.Single<IWindowService>()));
        }

        private void RegisterSaveLoadService()
        {
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IProgressService>(),
                _services.Single<IGameFactory>()));
        }

    }
}

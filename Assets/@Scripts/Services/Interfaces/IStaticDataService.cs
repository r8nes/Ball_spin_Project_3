using SpinProject.Data;

namespace SpinProject.Service
{
    public interface IStaticDataService : IService
    {
        LevelStaticData ForLevel(int levelKey);
        WindowConfigData ForWindow(WindowId windowId);

        void Load();
    }
}
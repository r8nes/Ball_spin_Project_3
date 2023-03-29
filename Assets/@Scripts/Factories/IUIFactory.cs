using SpinProject.Data;

namespace SpinProject.Service
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateWindowById(WindowId windowId);
    }
}
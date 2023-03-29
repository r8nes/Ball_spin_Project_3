using SpinProject.Data;

namespace SpinProject.Service
{
    public interface IWindowService : IService
    {
        public void Open(WindowId WindowId);
    }
}
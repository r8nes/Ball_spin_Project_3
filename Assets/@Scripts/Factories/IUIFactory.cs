using SpinProject.Data;
using UnityEngine;

namespace SpinProject.Service
{
    public interface IUIFactory : IService
    {
        GameObject CreateUIRoot();
        void AddLevelPanel(Transform root);
        void CreateWindowById(WindowId windowId);
    }
}
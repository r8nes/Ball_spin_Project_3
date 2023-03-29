using System;
using SpinProject.Data;
using UnityEngine;

namespace SpinProject.Service
{
    public interface IUIFactory : IService
    {
        GameObject CreateUIRoot();
        GameObject AddLevelPanel();
        void AddLevelButtons(Transform parent, Action action);
        void CreateWindowById(WindowId windowId);
    }
}
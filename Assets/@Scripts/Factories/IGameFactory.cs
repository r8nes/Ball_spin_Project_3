using System.Collections.Generic;
using SpinProject.Service;
using UnityEngine;

namespace SpinProject.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReader { get; }

        void Cleanup();
        GameObject CreateHud();
        GameObject CreatePlayer(Vector2 initialPoint);
    }
}
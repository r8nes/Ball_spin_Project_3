using System;
using SpinProject.Factory;
using UnityEngine;

namespace SpinProject.Data
{
    [Serializable]
    public class WindowConfigData
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}
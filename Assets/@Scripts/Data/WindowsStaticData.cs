using System.Collections.Generic;
using UnityEngine;

namespace SpinProject.Data
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/Window")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfigData> Configs;
    }
}
using System;
using System.Collections.Generic;

namespace SpinProject.Service
{
    [Serializable]
    public class PlayerProgress
    {
        public List<LevelInfo> Levels = new List<LevelInfo>();
    }
}
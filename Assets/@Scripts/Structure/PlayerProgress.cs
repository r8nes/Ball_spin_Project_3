using System;
using System.Collections.Generic;

namespace SpinProject.Service
{
    [Serializable]
    public class PlayerProgress
    {
        public List<Progress> Levels = new List<Progress>();
    }
}
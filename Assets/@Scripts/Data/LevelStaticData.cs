using UnityEngine;

namespace SpinProject.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public int LevelKey;
        public Vector2 InitialHeroPosition;
    }
} 
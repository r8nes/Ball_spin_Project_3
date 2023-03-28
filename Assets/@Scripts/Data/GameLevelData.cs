using System.Collections.Generic;
using UnityEngine;

namespace SpinProject.Data
{
    [CreateAssetMenu(fileName = "Level", menuName = "GameData/GameLevel")]
    public class GameLevelData : ScriptableObject
    {
        public List<SceneObject> Blocks = new List<SceneObject>();
        public Sprite BackGround;
    }
}
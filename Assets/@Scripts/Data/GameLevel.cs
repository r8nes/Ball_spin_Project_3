using System.Collections.Generic;
using UnityEngine;

namespace SpinPtoject.Data
{
    [CreateAssetMenu(fileName = "Level", menuName = "GameData/GameLevel")]
    public class GameLevel : ScriptableObject
    {
        public List<SceneObject> Blocks = new List<SceneObject>();
        public Sprite BackGround;
    }
}
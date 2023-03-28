using System.Collections.Generic;
using SpinProject.Data;
using UnityEngine;

namespace SpinProject.EditorTools
{
    public class SaveLevel
    {
        public void Save(GameLevelData gameLevel)
        {
            gameLevel.Blocks = new List<SceneObject>();
            BaseObject[] baseBlocks = GameObject.FindObjectsOfType<BaseObject>();

            foreach (var item in baseBlocks)
            {
                SceneObject blockObject = new SceneObject
                {
                    Position = item.gameObject.transform.position,
                    GameObject = item.ObjectData,
                };
                gameLevel.Blocks.Add(blockObject);
            }
        }
    }
}
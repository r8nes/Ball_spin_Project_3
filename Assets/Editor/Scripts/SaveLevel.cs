using System.Collections.Generic;
using SpinProject.Data;
using UnityEngine;

public class SaveLevel
{
    public void Save(GameLevel gameLevel)
    {
        gameLevel.Blocks = new List<SceneObject>();
        BaseObject[] baseBlocks = GameObject.FindObjectsOfType<BaseObject>();

        foreach (var item in baseBlocks)
        {
            SceneObject blockObject = new SceneObject
            {
                Position = item.gameObject.transform.position,
                Block = item.ObjectData,
            };
            gameLevel.Blocks.Add(blockObject);
        }
    }
}
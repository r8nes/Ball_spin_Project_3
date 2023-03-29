using SpinProject.Data;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace SpinProject.EditorTools
{
    public class ObjectGeneration
    {
        public void Generate(GameLevelData gameLevel, Transform parent)
        {
            for (int i = 0; i < gameLevel.Blocks.Count; i++)
            {
                GameObject element;
#if UNITY_EDITOR

                element = PrefabUtility.InstantiatePrefab(gameLevel.Blocks[i].GameObject.Prefab, parent) as GameObject;
                if (element.TryGetComponent(out BaseObject baseObject))
                {
                    baseObject.ObjectData = gameLevel.Blocks[i].GameObject;
                }
#else
            game = GameObject.Instantiate(gameLevel.Blocks[i].ObjectData.Prefab, parent);
#endif
                element.transform.position = gameLevel.Blocks[i].Position;
            }
        }
    }

}
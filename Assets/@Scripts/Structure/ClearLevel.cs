using SpinProject.Data;
using UnityEngine;

namespace SpinProject.EditorTools
{
    public class ClearLevel : MonoBehaviour
    {
        public void Clear()
        {
            BaseObject[] allObjects = FindObjectsOfType<BaseObject>();

            if (allObjects.Length > 0)
            {
                foreach (var item in allObjects)
                    DestroyItem(item.gameObject);
            }
        }
        private void DestroyItem(GameObject game)
        {
#if UNITY_EDITOR
            DestroyImmediate(game.gameObject);
#else
                Destroy(game.gameObject);
#endif
        }
    }
}
using UnityEngine;

namespace SpinProject.Data
{
    public abstract class BaseObject : MonoBehaviour
    {
#if UNITY_EDITOR
        public GameObjectData ObjectData;
#endif
    }
}
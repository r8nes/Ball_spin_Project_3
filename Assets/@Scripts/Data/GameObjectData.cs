using UnityEngine;

namespace SpinProject.Data
{
    [CreateAssetMenu(fileName = "ObjectData", menuName = "GameData/ObjectData")]
    public class GameObjectData : ScriptableObject
    {
        public GameObject Prefab;
    }
}
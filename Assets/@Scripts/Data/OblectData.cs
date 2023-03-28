using UnityEngine;

namespace SpinPtoject.Data
{
    [CreateAssetMenu(fileName = "ObjectData", menuName = "GameData/ObjectData")]
    public class OblectData : ScriptableObject
    {
        public GameObject Prefab;
    }
}
using System.Collections.Generic;
using SpinProject.EditorTools;
using UnityEngine;

namespace SpinProject.Data
{
    [CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Create/Data")]
    public class EditorData : ScriptableObject
    {
        public List<EditorBlockData> BlockDatas = new List<EditorBlockData>();
    }
}
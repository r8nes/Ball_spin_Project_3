using System.Collections;
using UnityEngine;

namespace SpinProject.Structure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

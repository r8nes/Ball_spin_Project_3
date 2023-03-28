using System.Collections;
using UnityEngine;

namespace SpinPtoject.Structure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

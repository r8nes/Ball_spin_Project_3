using UnityEngine;

namespace SpinProject.Logic
{
    public class FallCheck : MonoBehaviour
    {
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minY;

        private void Update()
        {
            // TODO
            Check();
        }

        private void Check()
        {
            if (transform.position.y < _minY || transform.position.x > _maxX || transform.position.x < _minX)
            {
                Debug.Log("Defeat");
                return;
            }
        }
    }
}

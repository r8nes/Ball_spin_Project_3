using UnityEngine;

namespace SpinProject.Logic
{
    //TODO Construct
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float minY;
        [SerializeField] private float maxY;

        [SerializeField] private Transform _target;
     
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            FollowTarget(_target);
        }

        private void FollowTarget(Transform target)
        {
            if (target != null)
            {
                transform.position = target.position + offset;
                Vector3 position = transform.position;
                position.y = Mathf.Clamp(position.y, minY, maxY);
                transform.position = position;
            }
        }
    }
}

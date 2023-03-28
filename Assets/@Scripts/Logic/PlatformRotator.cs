using UnityEngine;

namespace SpinProject.Logic
{
    public class PlatformRotator : MonoBehaviour
    {
        [SerializeField] private float _rotateBy;
        [SerializeField] private float _minRotSpeed;
        [SerializeField] private float _maxRotSpeed;
        [SerializeField] private float _maxPressHoldTime;

        [SerializeField] private Rigidbody2D _platform;

        private float _pressHoldTime;

        private void Update()
        {
            float direction = -Input.GetAxisRaw("Horizontal");

            RotationSpeed(direction);

            if (direction == 0f)
            {
                _platform.freezeRotation = true;
                return;
            }

            _platform.freezeRotation = false;
            _platform.angularVelocity = _rotateBy * direction;
        }

        private void RotationSpeed(float direction)
        {
            if (direction != 0f)
            {
                float num = _pressHoldTime / _maxPressHoldTime;

                _rotateBy = _minRotSpeed + (_maxRotSpeed - _minRotSpeed) * num;
                _rotateBy = Mathf.Clamp(_rotateBy, _minRotSpeed, _maxRotSpeed);

                _pressHoldTime += Time.deltaTime;
                _pressHoldTime = Mathf.Clamp(_pressHoldTime, 0f, _maxPressHoldTime);
                
                return;
            }

            _rotateBy = _minRotSpeed;
            _pressHoldTime = 0f;
        }
    }
}

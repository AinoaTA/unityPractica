using UnityEngine;

namespace PlayerSettings
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rb;
        private Vector2 _dir;

        private void OnEnable()
        {
            InputManager.OnMoveDelegate += Movement;
        }

        private void OnDisable()
        {
            InputManager.OnMoveDelegate -= Movement;
        }

        private void Awake()
        {
            TryGetComponent(out _rb);
        }

        private void Movement(Vector2 dir)
        {
            _dir = dir;
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _speed * Time.fixedDeltaTime * _dir);
        }
    }
}
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _baseSpeed = 2;
        [SerializeField] private float _damage;
        private Vector2 _dir;

        public void Init(Vector2 dir)
        {
            _dir = dir;
        }

        private void Update()
        {
            transform.Translate(_baseSpeed * Time.deltaTime * _dir);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("CanBeHit"))
            {
                //Check if the collision has the interface to make damage.
                if (collision.TryGetComponent(out Interfaces.IDamage d))
                {
                    d.Damage(_damage);
                }
            }
        }
    }
}
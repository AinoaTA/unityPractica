using System;
using UnityEngine;

namespace LifeSystem
{
    public class LifeSystem : MonoBehaviour
    {
        [SerializeField] private float _maxLife;

        private float _currentLife = 80;

        //To notify LifeSystemUI player
        public Action<float> OnLifeUpdate;

        private void Awake()
        {
            OnLifeUpdate?.Invoke(_currentLife);
        }
        /// <summary>
        /// Apply damage and check if entity is dead.
        /// </summary>
        /// <param name="hit"></param>
        public void Damage(float hit)
        {
            hit = Mathf.Abs(hit);

            _currentLife -= hit;

            _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);

            OnLifeUpdate?.Invoke(_currentLife);

            if (_currentLife <= 0)
            {
                Dead();
                return;
            }
        }

        /// <summary>
        /// Healing entity.
        /// </summary>
        /// <param name="heal"></param>
        public void Healing(float heal)
        {
            heal = Mathf.Abs(heal);

            _currentLife += heal;

            _currentLife = Mathf.Clamp(_currentLife, 0, _maxLife);

            OnLifeUpdate?.Invoke(_currentLife);
        }

        public void Dead()
        {


        }
    }
}
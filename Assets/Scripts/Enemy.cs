using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, Interfaces.IDamage
    {
        private LifeSystem.LifeSystem _lifeSystem;

        private void Awake()
        {
            TryGetComponent(out _lifeSystem);
        }

        public void Damage(float hit)
        {
            _lifeSystem.Damage(hit);
        }
    }
}
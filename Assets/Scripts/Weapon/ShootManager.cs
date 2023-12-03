using UnityEngine;

namespace Shooting
{
    public class ShootManager
    {
        private BulletPooling _pooling;
        private int _maxBulletsSave;
        private int _currentBulletsInCharge;
         
        public delegate void ShootDelegate(int curr, int max);
        public static ShootDelegate OnShoot;

        /// <summary>
        /// Constructor. Set up magazine capacity.
        /// </summary>
        /// <param name="maxBullets"> Set the max quantity of bullets can be possible in magazine</param>
        public ShootManager(int maxBullets)
        {
            _maxBulletsSave = maxBullets;
            _currentBulletsInCharge = _maxBulletsSave;

            _pooling = Controller.Instance.Pooling;

            OnShoot?.Invoke(_currentBulletsInCharge, _maxBulletsSave);
        }

        /// <summary>
        /// Take into account if there is bullets in magazine and also if there is no any pool object enable for use.
        /// If all is correct, player makes a shoot.
        /// </summary>
        /// <param name="spawnPoint"></param>
        /// <param name="dir"></param>
        public void MakeBullet(Transform spawnPoint, Vector2 dir)
        {
            if (_currentBulletsInCharge <= 0) return;

            Bullet b = _pooling.GetEntityPooling();

            if (b == null) return;
            _currentBulletsInCharge--;

            //update Bullets UI
            OnShoot?.Invoke(_currentBulletsInCharge, _maxBulletsSave);

            b.transform.position = spawnPoint.position;
            b.gameObject.SetActive(true);
            b.Init(dir); //Bullet Initialize
        }

        /// <summary>
        /// Add bullets to magazine.
        /// </summary>
        /// <param name="bulletsToAdd"></param>
        public void AddBullets(int bulletsToAdd) 
        {
            _currentBulletsInCharge += bulletsToAdd; 
            _currentBulletsInCharge = Mathf.Clamp(_currentBulletsInCharge, 0, _maxBulletsSave);
            OnShoot?.Invoke(_currentBulletsInCharge, _maxBulletsSave);
        } 
    }
}
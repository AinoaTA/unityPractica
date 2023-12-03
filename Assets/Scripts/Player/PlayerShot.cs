using UnityEngine;

namespace PlayerSettings
{
    public class PlayerShot : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        private Camera _cam;
        private Vector3 _lookDir;
        private Shooting.ShootManager _manager;

        private void OnEnable()
        {
            InputManager.OnShotDelegate += Shot;
            Items.Bullets.OnAddBullets += Recharge;
        }

        private void OnDisable()
        {
            InputManager.OnShotDelegate -= Shot;
            Items.Bullets.OnAddBullets -= Recharge;
        }

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Start()
        {
            _manager = new(45);
        }

        public void Shot()
        {
            _manager.MakeBullet(_spawnPoint, transform.up);
        }

        private void Recharge(int quantity)
        {
            _manager.AddBullets(quantity);
        }

        private void Update()
        {
            _lookDir = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(Vector3.forward, _lookDir),
                720 * Time.deltaTime);
        }
    }
}
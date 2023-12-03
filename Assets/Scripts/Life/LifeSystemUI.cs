using UnityEngine;
using UnityEngine.UI;

namespace LifeSystem.UI
{
    public class LifeSystemUI : MonoBehaviour
    {
        [SerializeField] private LifeSystem _playerLifeSystem;
        [SerializeField] private Image _lifeImage;

        private void OnEnable()
        {
            _playerLifeSystem.OnLifeUpdate += UpdateUI;
        }

        private void OnDisable()
        {
            _playerLifeSystem.OnLifeUpdate -= UpdateUI;
        }

        public void UpdateUI(float life)
        {
            _lifeImage.fillAmount = life / 100;
        }
    }
}
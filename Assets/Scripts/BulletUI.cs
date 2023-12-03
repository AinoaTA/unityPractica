using TMPro;
using UnityEngine;

public class BulletUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletText;

    private void OnEnable()
    {
        Shooting.ShootManager.OnShoot += UpdateStats;
    }

    private void OnDisable()
    {
        Shooting.ShootManager.OnShoot -= UpdateStats;
    }

    private void UpdateStats(int curr, int max)
    {
        _bulletText.text = curr + "/" + max;
    }
}
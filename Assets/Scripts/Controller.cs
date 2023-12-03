using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller Instance;

    public Transform ParentBullets { get => _parentBullets; }
    [SerializeField] private Transform _parentBullets;

    public BulletPooling Pooling { get; private set; }

    //the bullet type of the current level.
    [SerializeField] private Shooting.Bullet _defaultBullet;

    private void Awake()
    {
        Instance = this;

        Pooling = new(_defaultBullet, ParentBullets, 20, true);
    }
}
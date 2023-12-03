using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specific class pool for bullets.
/// </summary>
public class BulletPooling
{
    private List<Shooting.Bullet> _pooling = new();

    private readonly Shooting.Bullet _prefab;
    private readonly Transform _parent;
    private readonly int _stock;
    private readonly bool _isDynamic;

    public BulletPooling(Shooting.Bullet gm, Transform parent, int stock, bool dynamic)
    {
        _prefab = gm;
        _parent = parent;
        _stock = stock;
        _isDynamic = dynamic;

        GenerateGameObjects(_stock);
    }

    protected virtual void GenerateGameObjects(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Shooting.Bullet gm = GameObject.Instantiate(_prefab, Vector2.zero, Quaternion.identity, _parent);
            gm.gameObject.SetActive(false);

            _pooling.Add(gm);
        }
    }

    public Shooting.Bullet GetEntityPooling()
    { 
        //Checking if there is a bullet hide in the hierarchy to use.
        var e = _pooling.Find(e => e.gameObject.activeInHierarchy == false);
         
        if (_isDynamic)
        { 
            //if not, it creates 10 more bullets.
            if (e == null)
                GenerateGameObjects(10);
             
            //and find again.
            return _pooling.Find(n => !n.gameObject.activeInHierarchy);
        }

        return e; //always return something if its dynamic.
    }

    public List<Shooting.Bullet> GetPooling() => _pooling;
}

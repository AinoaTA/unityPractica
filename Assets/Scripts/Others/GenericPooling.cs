using System.Collections.Generic;
using UnityEngine;

public class GenericPooling 
{
    private List<GameObject> _pooling = new();

    private GameObject _prefab;
    private Transform _parent;
    private int _stock;
    private bool _isDynamic;

    private int index;

    public GenericPooling(GameObject gm, Transform parent, int stock, bool dynamic)
    {
        _prefab = gm;
        _parent = parent;
        _stock = stock;
        _isDynamic = dynamic;

        GenerateGameObjects(_stock);
    }

    private void GenerateGameObjects (int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var gm = Object.Instantiate(_prefab, Vector2.zero, Quaternion.identity, _parent) ;
            //gm..SetActive(false);

            _pooling.Add(gm);
        }
    }

    public GameObject GetEntityPooling()
    {
        var e = _pooling.Find(e => e.activeInHierarchy == false);

        if (_isDynamic)
        {
            if (e == null)
                GenerateGameObjects(10);

            return _pooling.Find(n => !n.activeInHierarchy);
        }

        return e; 
    }

    public List<GameObject> GetPooling() => _pooling;
}

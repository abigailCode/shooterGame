using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance;
    List<GameObject> _pooledObjects = new List<GameObject>();
    [SerializeField] int _amountToPool = 20;
    [SerializeField] GameObject _bulletPrefab;

    void Awake() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
    }

    void Start() {
        for (int i = 0; i < _amountToPool; i++) {
            GameObject obj = Instantiate(_bulletPrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < _pooledObjects.Count; i++)
            if (!_pooledObjects[i].activeInHierarchy) return _pooledObjects[i];
        return null;
    }

}

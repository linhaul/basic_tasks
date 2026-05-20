using System.Collections.Generic;
using UnityEngine;

namespace Sandbox.Task12
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _initialSize = 10;
        [SerializeField] private Transform _parent;

        private readonly Queue<GameObject> _pool = new Queue<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < _initialSize; i++)
            {
                GameObject obj = CreateNewInstance();
                _pool.Enqueue(obj);
            }
        }

        public GameObject Get()
        {
            GameObject obj = _pool.Count > 0
                ? _pool.Dequeue()
                : CreateNewInstance();

            obj.SetActive(true);

            if (obj.TryGetComponent<IPoolable>(out var poolable))
            {
                poolable.OnSpawnFromPool();
            }
            
            if (obj.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.SetPool(this);
            }

            return obj;
        }

        private GameObject CreateNewInstance()
        {
            GameObject enemy = Instantiate(_enemyPrefab, _parent);
            enemy.SetActive(false);
            return enemy;
        }

        public void Return(GameObject obj)
        {
            if (obj.TryGetComponent<IPoolable>(out var poolable))
            {
                poolable.OnReturnToPool();
            }

            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Sandbox.Task12.BuiltIn
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxSize = 100;
        [SerializeField] private Transform _parent;

        private ObjectPool<Enemy> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Enemy>(
                createFunc: () =>
                {
                    Enemy enemy = Instantiate(_enemyPrefab, _parent);
                    enemy.SetPool(this);
                    return enemy;
                },
                actionOnGet: enemy =>
                {
                    enemy.gameObject.SetActive(true);
                    enemy.OnSpawnFromPool();
                },
                actionOnRelease: enemy =>
                {
                    enemy.gameObject.SetActive(false);
                    enemy.OnReturnToPool();
                },
                actionOnDestroy: enemy => Destroy(enemy.gameObject),
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
                );
        }

        public Enemy Get() => _pool.Get();
        public void Return(Enemy enemy) => _pool.Release(enemy);
    }
}

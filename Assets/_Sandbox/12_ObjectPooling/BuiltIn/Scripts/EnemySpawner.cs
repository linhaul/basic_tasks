using System.Collections;
using UnityEngine;

namespace Sandbox.Task12.BuiltIn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _pool;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private int _enemiesPerWave = 5;
        [SerializeField] private float _waveDelay = 3f;
        [SerializeField] private Vector2 _spawnAreaMin = new Vector2(-5, -3);
        [SerializeField] private Vector2 _spawnAreaMax = new Vector2(5, 3);


        private void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        private IEnumerator SpawnWaves()
        {
            while (true)
            {
                for (int i = 0; i < _enemiesPerWave; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(_spawnInterval);
                }
                yield return new WaitForSeconds(_waveDelay);
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _pool.Get();
            enemy.transform.position = GetSpawnPosition();
        }

        private Vector3 GetSpawnPosition()
        {
            float x = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
            float y = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);

            return new Vector3(x, y, 0);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Sandbox.Task07
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private EnemySimple[] _enemyPrefabs;
        [SerializeField] private Vector2 _spawnAreaMin = new Vector2(-5, -3);
        [SerializeField] private Vector2 _spawnAreaMax = new Vector2(5, 3);
        [SerializeField] private Transform _container;
        [SerializeField] private int _enemiesPerWave = 5;
        [SerializeField] private float _delayBetweenSpawns = 0.5f;

        private Coroutine _waveCoroutine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) SpawnWave();
            if (Input.GetKeyDown(KeyCode.K)) KillRandomEnemy();
            if (Input.GetKeyDown(KeyCode.C)) KillAllEnemy();
        }

        private void KillAllEnemy()
        {
            if (_container == null) return;

            foreach (Transform enemy in _container)
            {
                Destroy(enemy.gameObject);
            }
        }

        private void KillRandomEnemy()
        {
            if (_container == null || _container.childCount == 0) return; 

            int randomIndex = Random.Range(0, _container.childCount);
            Transform child = _container.GetChild(randomIndex);

            EnemySimple enemy = child.GetComponent<EnemySimple>();
            if (enemy != null) enemy.Defeat();
        }

        private void SpawnWave()
        {
            if (_waveCoroutine != null) return;
            _waveCoroutine = StartCoroutine(WaveRoutine());
        }

        private void SpawnRandomEnemy()
        {
            int randomIndex = Random.Range(0, _enemyPrefabs.Length);
            EnemySimple prefab = _enemyPrefabs[randomIndex];

            Instantiate(prefab, GetRandomPosition(), Quaternion.identity, _container);
        }

        private IEnumerator WaveRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(_delayBetweenSpawns);

            for (int i = 0; i < _enemiesPerWave; i++)
            {
                SpawnRandomEnemy();
                yield return wait;
            }

            _waveCoroutine = null;
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
            float y = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);
            return new Vector3(x, y, 0);
        }
    }
}

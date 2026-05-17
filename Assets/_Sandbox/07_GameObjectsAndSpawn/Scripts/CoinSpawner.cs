using UnityEngine;

namespace Sandbox.Task07
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Vector2 _spawnAreaMin = new Vector2(-5, -3);
        [SerializeField] private Vector2 _spawnAreaMax = new Vector2(5, 3);
        [SerializeField] private Transform _coinsContainer;
        [SerializeField] private int _burstCount = 10;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Spawn();
            if (Input.GetKeyDown(KeyCode.B)) SpawnBurst();
            if (Input.GetKeyDown(KeyCode.C)) ClearBoard();
        }

        private void Spawn()
        {
            if (_coinPrefab == null || _coinsContainer == null) return;
            Instantiate(_coinPrefab, GetRandomPosition(), Quaternion.identity, _coinsContainer);
        }

        private void SpawnBurst()
        {
            for (int i = 0; i < _burstCount; i++)
            {
                Spawn();
            }
        }

        private void ClearBoard()
        {
            if (_coinsContainer == null) return;
            foreach (Transform child in _coinsContainer)
            {
                Destroy(child.gameObject);
            }
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(_spawnAreaMin.x, _spawnAreaMax.x);
            float y = Random.Range(_spawnAreaMin.y, _spawnAreaMax.y);
            return new Vector3( x, y, 0 );
        }
    }
}
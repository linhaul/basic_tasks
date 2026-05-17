using UnityEngine;

namespace Sandbox.Task07
{
    public class CoinCollector : MonoBehaviour
    {
        private int _coinSpawnedCount = 0;
        private int _cointTotalValue = 0;
        private void OnEnable()
        {
            Coin.OnCoinSpawned += HandleCoinSpawned;
            Coin.OnCoinDestroyed += HandleCoinDestroyed;
        }

        private void OnDisable()
        {
            Coin.OnCoinSpawned -= HandleCoinSpawned;
            Coin.OnCoinDestroyed -= HandleCoinDestroyed;
        }

        private void HandleCoinSpawned(Coin coin)
        {
            _coinSpawnedCount++;
            _cointTotalValue += coin.Value;
            Debug.Log($"Текущее количество монет: {_coinSpawnedCount}, текущая общая ценность: {_cointTotalValue}");
        }

        private void HandleCoinDestroyed(Coin coin)
        {
            _coinSpawnedCount--;
            _cointTotalValue -= coin.Value;
            Debug.Log($"Текущее количество монет: {_coinSpawnedCount}, текущая общая ценность: {_cointTotalValue}");
        }
    }
}


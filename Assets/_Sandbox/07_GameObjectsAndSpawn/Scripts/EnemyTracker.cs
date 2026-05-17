using UnityEngine;

namespace Sandbox.Task07
{
    public class EnemyTracker : MonoBehaviour
    {
        private int _liveCount = 0;
        private int _totalSpawned = 0;
        private int _totalCoins = 0;
        private int _defeatedCount = 0;

        private void OnEnable()
        {
            EnemySimple.OnAnyEnemySpawned += HandleSpawned;
            EnemySimple.OnAnyEnemyDefeated += HandleDefeated;
            EnemySimple.OnAnyEnemyDestroyed += HandleDestroyed;
        }

        private void OnDisable()
        {
            EnemySimple.OnAnyEnemySpawned -= HandleSpawned;
            EnemySimple.OnAnyEnemyDefeated -= HandleDefeated;
            EnemySimple.OnAnyEnemyDestroyed -= HandleDestroyed;
        }
        

        private void HandleSpawned(EnemySimple enemy)
        {
            _totalSpawned++;
            _liveCount++;
            LogPrint();
        }

        private void HandleDefeated(EnemySimple enemy)
        {
            _defeatedCount++;
            _totalCoins += enemy.Reward;
            LogPrint();
        }

        private void HandleDestroyed(EnemySimple enemy)
        {
            _liveCount--;
            LogPrint();
        }

        private void LogPrint()
        {
            Debug.Log($"Live: {_liveCount}, Spawned: {_totalSpawned}, Defeated: {_defeatedCount}, Coins: {_totalCoins}");
        }
    }
}

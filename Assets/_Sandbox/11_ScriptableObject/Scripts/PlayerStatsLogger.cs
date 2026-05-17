using UnityEngine;

namespace Sandbox.Task11
{
    public class PlayerStatsLogger : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerBalance _playerBalance;

        private void OnEnable()
        {
            _playerHealth.OnHealthChange += HandleHealth;
            _playerHealth.OnDied += HandleDeath;
            _playerBalance.OnCoinsChanged += HandleBalance;
        }

        private void OnDisable()
        {
            _playerHealth.OnHealthChange -= HandleHealth;
            _playerHealth.OnDied -= HandleDeath;
            _playerBalance.OnCoinsChanged -= HandleBalance;
        }

        private void HandleHealth(string name, int damage, int currentHealth, int maxHealth) => Debug.Log($"Damage from: {name} - {damage}; HP: {currentHealth}/{maxHealth}");
        private void HandleDeath() => Debug.Log("Died");
        private void HandleBalance(string name, int amount, int total) => Debug.Log($"Coin {name} + {amount}, Balance: {total}");
    }
}

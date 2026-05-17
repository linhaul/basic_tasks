using UnityEngine;

namespace Sandbox.Task09
{
    public class PlayerStateLogger : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerBalance _playerBalance;

        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += HandleHealth;
            _playerHealth.OnDied += HandleDeath;
            _playerBalance.OnCoinsChanged += HandleBalance;
        }

        private void OnDisable()
        {
            _playerHealth.OnHealthChanged -= HandleHealth;
            _playerHealth.OnDied -= HandleDeath;
            _playerBalance.OnCoinsChanged -= HandleBalance;
        }

        private void HandleHealth(int currentHealth, int maxHealth)
        {
            Debug.Log($"HP: {currentHealth}/{maxHealth}");
        }

        private void HandleBalance(int total)
        {
            Debug.Log($"Coins: {total}");
        }    

        private void HandleDeath()
        {
            Debug.Log("GAME OVER");
        }
    }
}

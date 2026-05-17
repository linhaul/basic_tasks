using System;
using UnityEngine;

namespace Sandbox.Task05
{
    public class HealthLogger : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private void OnEnable()
        {
            _player.OnHealthChanged += PrintHealthStatus;
        }

        private void OnDisable()
        {
            _player.OnHealthChanged -= PrintHealthStatus;
        }

        private void PrintHealthStatus(int currentHealth, int maxHealth)
        {
            Debug.Log($"{_player.Name} имеет здоровье в размере: {currentHealth}/{maxHealth}");
        }
    }
}


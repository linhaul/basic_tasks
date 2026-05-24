using System;
using UnityEngine;

namespace Sandbox.Task13
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        public event Action OnDied;

        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;

        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        public void TakeDamage(int damage, string source = "Unknown")
        {
            if (!IsAlive) return;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);

            if (CurrentHealth == 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}

using System;
using UnityEngine;

namespace Sandbox.Task11
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;

        public event Action<string, int, int, int> OnHealthChange;
        public event Action OnDied;

        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        public void TakeDamage(int damage, string source = "Unknown")
        {
            if (!IsAlive) return;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);
            OnHealthChange?.Invoke(source, damage, CurrentHealth, _maxHealth);

            if (CurrentHealth == 0) OnDied?.Invoke();
        }
    }
}

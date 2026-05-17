using System;
using UnityEngine;

namespace Sandbox.Task09
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;

        public event Action OnDied;
        public event Action<int, int> OnHealthChanged;


        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }
        public void TakeDamage(int damage)
        {
            if (!IsAlive) return;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);

            if (CurrentHealth == 0) OnDied?.Invoke();
        }
    }
}

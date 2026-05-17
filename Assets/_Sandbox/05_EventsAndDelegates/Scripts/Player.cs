using System;
using UnityEngine;

namespace Sandbox.Task05
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _level = 1;
        [SerializeField] private string _name = "Steve";

        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;
        public string Name { get; private set; }

        public event Action<int, int> OnHealthChanged;
        public event Action OnDied;
        public event Action<int> OnLevelUp;

        private void Awake()
        {
            CurrentHealth = _maxHealth;
            Name = _name;
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) return;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);

            if (CurrentHealth == 0)
            {
                OnDied?.Invoke();
            }
        }

        public void Heal(int amount)
        {
            if (!IsAlive) return;

            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, _maxHealth);
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);
        }

        public void LevelUp()
        {
            if (!IsAlive) return;

            _level++;
            _maxHealth += 10;
            CurrentHealth = _maxHealth;

            OnLevelUp?.Invoke(_level);
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);
        }
    }
}


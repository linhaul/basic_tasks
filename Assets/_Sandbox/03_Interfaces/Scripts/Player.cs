using UnityEngine;

namespace Sandbox.Task03
{
    public class Player : IDamageable
    {
        public int MaxHealth { get; }
        public string Name { get; }
        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;

        public Player(string name, int maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) return;
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

            Debug.Log($"Player получил урон в размере: {damage}, текущее хп: {CurrentHealth}/{MaxHealth}");
        }

        public void Heal(int amount)
        {
            if (!IsAlive) return;
            
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            Debug.Log($"Player восстановил здоровье в размере: {amount}, текущее хп: {CurrentHealth}/{MaxHealth}");
        }
    }
}

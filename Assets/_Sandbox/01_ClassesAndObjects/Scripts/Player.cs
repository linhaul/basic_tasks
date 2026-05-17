using UnityEngine;

namespace Sandbox.Task01
{
    public class Player
    {
        public string Name { get; }
        public int Level { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        private const int HealthPerLevel = 10;

        public Player(int maxHealth, string name)
        {
            Level = 1;
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0) return;
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            Debug.Log($"{Name} получил {damage} урона. HP: {CurrentHealth}/{MaxHealth}");
        }

        public void Heal(int amount)
        {
            if (amount < 0) return;
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            Debug.Log($"{Name} вылечен на {amount}. HP: {CurrentHealth}/{MaxHealth}");
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += HealthPerLevel;
            CurrentHealth = MaxHealth;
            Debug.Log($"{Name} получил уровень {Level}!");
        }

        public void Status()
        {
            Debug.Log($"{Name} — уровень {Level}, HP: {CurrentHealth}/{MaxHealth}");
        }
    }
}

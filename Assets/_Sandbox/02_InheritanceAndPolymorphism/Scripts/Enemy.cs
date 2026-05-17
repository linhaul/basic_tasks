using UnityEngine;

namespace Sandbox.Task02
{
    public class Enemy
    {
        public string Name { get; }
        public int MaxHealth { get; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Enemy(string name, int maxHealth, int damage)
        {
            Name = name;
            Health = maxHealth;
            Damage = damage;
            MaxHealth = maxHealth;
        }
        public virtual void Attack(Enemy target)
        {
            if (target == null) return;

            Debug.Log($"{Name} нанес {Damage} урона противнику {target.Name}");

            target.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int damage)
        {
            if (Health <= 0) return;

            Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
            Debug.Log($"{Name} получил урон в размере: {damage}, текущее здоровье: {Health}");

            if (Health == 0) OnDeath();
        }

        protected virtual void OnDeath()
        {
            Debug.Log($"{Name} погиб!");
        }
    }
}


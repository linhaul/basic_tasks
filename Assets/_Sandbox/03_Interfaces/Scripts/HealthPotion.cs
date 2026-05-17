using UnityEngine;

namespace Sandbox.Task03
{
    public class HealthPotion : ICollectible, IDamageable
    {
        public bool IsCollected { get; private set; } = false;
        public int CurrentHealth { get; private set; } = 1;
        public bool IsAlive => CurrentHealth > 0;

        private Player _player;
        private int _healAmount;

        public HealthPotion(Player player, int healAmount)
        {
            _healAmount = healAmount;
            _player = player;
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) return;
            CurrentHealth = 0;

            Debug.Log($"Potion был сломан и утрачен навсегда...");
        }

        public void Collect()
        {
            if (IsCollected)
            {
                Debug.Log($"Уже подобрано!");
                return;
            }

            if (!IsAlive)
            {
                Debug.Log($"Зелье разбито");
                return;
            }

            _player.Heal(_healAmount);

            IsCollected = true;
            Debug.Log($"Подобрал и использовал Potion!");
        }
    }
}


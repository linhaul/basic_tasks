using UnityEngine;

namespace Sandbox.Task03
{
    public class TestInterfaces : MonoBehaviour
    {
        void Start()
        {
            Player player = new Player("Steve", 100);
            Coin coin = new Coin(50);
            HealthPotion potion = new HealthPotion(player, 50);

            player.TakeDamage(40);   

            Debug.Log("=== Тест 1: полиморфизм через IDamageable ===");
            IDamageable[] damageables = { player, potion };

            foreach (IDamageable target in damageables)
            {
                target.TakeDamage(10);
            }

            Debug.Log("=== Тест 2: повторный удар по разбитому зелью ===");
            potion.TakeDamage(5);

            Debug.Log("=== Тест 3: попытка подобрать разбитое зелье ===");
            int hpBefore = player.CurrentHealth;
            potion.Collect();
            int hpAfter = player.CurrentHealth;
            Debug.Log($"HP до: {hpBefore}, HP после: {hpAfter} (должно быть равно)");

            Debug.Log("=== Тест 4: полиморфизм через ICollectible ===");
            HealthPotion freshPotion = new HealthPotion(player, 50);
            ICollectible[] collectibles = { coin, freshPotion };

            foreach (ICollectible item in collectibles)
            {
                item.Collect();
            }

            Debug.Log("=== Тест 5: повторный подбор уже собранных предметов ===");
            coin.Collect();
            freshPotion.Collect();

            Debug.Log("=== Финальное состояние ===");
            Debug.Log($"Игрок: HP {player.CurrentHealth}/{player.MaxHealth}, жив: {player.IsAlive}");
            Debug.Log($"Монета: подобрана = {coin.IsCollected}, ценность {coin.Amount}");
            Debug.Log($"Зелье: разбитое подобрано = {potion.IsCollected}, целое подобрано = {freshPotion.IsCollected}");
        }
    }
}


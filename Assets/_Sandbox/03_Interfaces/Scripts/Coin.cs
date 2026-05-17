using UnityEngine;

namespace Sandbox.Task03
{
    public class Coin : ICollectible
    {
        public bool IsCollected { get; private set; } = false;
        public int Amount { get; private set; }
        
        public Coin(int amount)
        {
            Amount = amount;
        }
        public void Collect()
        {
            if (IsCollected)
            {
                Debug.Log($"Уже подобрано!");
                return;
            }

            IsCollected = true;
            Debug.Log($"Подобрал {Amount} монет");
        }
    }
}

using System;
using UnityEngine;

namespace Sandbox.Task09
{
    public class PlayerBalance : MonoBehaviour
    {
        public int Coins {  get; private set; }

        public event Action<int> OnCoinsChanged;

        private void OnEnable()
        {
            Coin.OnAnyCoinCollected += AddCoins;
        }

        private void OnDisable()
        {
            Coin.OnAnyCoinCollected -= AddCoins;
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnCoinsChanged?.Invoke(Coins);
        }
    }
}

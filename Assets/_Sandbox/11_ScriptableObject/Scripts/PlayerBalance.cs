using System;
using UnityEngine;

namespace Sandbox.Task11
{
    public class PlayerBalance : MonoBehaviour
    {
        public int Coins { get; private set; }

        public event Action<string, int, int> OnCoinsChanged;

        private void OnEnable()
        {
            Coin.OnAnyCoinCollected += AddCoins;
        }

        private void OnDisable()
        {
            Coin.OnAnyCoinCollected -= AddCoins;
        }

        public void AddCoins(string name, int amount)
        {
            Coins += amount;
            OnCoinsChanged?.Invoke(name, amount, Coins);
        }
    }
}

using UnityEngine;
using System;

namespace Sandbox.Task09
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinValue = 10;

        public static event Action<int> OnAnyCoinCollected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            OnAnyCoinCollected?.Invoke(_coinValue);
            Destroy(gameObject);
        }
    }
}


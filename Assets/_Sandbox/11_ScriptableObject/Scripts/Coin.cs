using System;
using UnityEngine;

namespace Sandbox.Task11
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private CoinData _coinData;

        private SpriteRenderer _sr;

        public static event Action<string, int> OnAnyCoinCollected;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (_coinData == null) return;
            _sr.color = _coinData.Color;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            OnAnyCoinCollected?.Invoke(_coinData.CoinName, _coinData.Value);
            Destroy(gameObject);
        }
    }
}


using System;
using UnityEngine;

namespace Sandbox.Task13
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private CoinData _coinData;

        private SpriteRenderer _sr;

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

            GameManager.Instance.AddScore(_coinData.Value);
            Destroy(gameObject);
        }
    }
}


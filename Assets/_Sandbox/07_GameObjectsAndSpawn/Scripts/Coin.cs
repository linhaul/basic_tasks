using System;
using UnityEngine;

namespace Sandbox.Task07
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _value = 10;
        [SerializeField] private float _lifetime = 5f;

        public static event Action<Coin> OnCoinSpawned;
        public static event Action<Coin> OnCoinDestroyed;

        public int Value => _value;

        private void Start()
        {
            Vector3 pos = gameObject.transform.position;
            OnCoinSpawned?.Invoke(this);
            Debug.Log($"Создана монетка, с ценностью: {Value} позиция: {pos.x:F1}, {pos.y:F1}");

            Destroy(gameObject, _lifetime);
        }

        private void OnDestroy()
        {
            Debug.Log($"Монетка уничтожена");

            OnCoinDestroyed?.Invoke(this);
        }
    }
}

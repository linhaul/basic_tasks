using UnityEngine;

namespace Sandbox.Task09
{
    public class DangerZone : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private bool _isContinuous = false;
        [SerializeField] private float _damageInterval = 0.5f;

        private float _lastDamageTime;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<PlayerHealth>(out PlayerHealth player)) return;

            player.TakeDamage(_damage);
            _lastDamageTime = Time.time;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_isContinuous) return;
            if (!other.TryGetComponent<PlayerHealth>(out PlayerHealth player)) return;

            if (Time.time - _lastDamageTime >= _damageInterval)
            {
                player.TakeDamage(_damage);
                _lastDamageTime = Time.time;
            }
        }
    }
}


using UnityEngine;

namespace Sandbox.Task11
{
    public class Hazard : MonoBehaviour
    {
        [SerializeField] private HazardData _hazardData;

        private SpriteRenderer _sr;

        private float _lastDamageTime = float.NegativeInfinity;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (_hazardData == null) return;
            _sr.color = _hazardData.Color;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent<PlayerHealth>(out var player)) return;

            if (Time.time - _lastDamageTime < _hazardData.DamageInterval) return;

            player.TakeDamage(_hazardData.Damage, _hazardData.HazardName);
            _lastDamageTime = Time.time;
        }
    }
}

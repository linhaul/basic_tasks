using UnityEngine;

namespace Sandbox.Task13
{
    [CreateAssetMenu(fileName = "HazardData", menuName = "Sandbox/Task13/Hazard Data")]
    public class HazardData : ScriptableObject
    {
        [SerializeField] private string _hazardName;
        [SerializeField] private int _damage;
        [SerializeField] private float _damageInterval;
        [SerializeField] private Color _color;

        public string HazardName => _hazardName;
        public int Damage => _damage;
        public float DamageInterval => _damageInterval;
        public Color Color => _color;
    }
}

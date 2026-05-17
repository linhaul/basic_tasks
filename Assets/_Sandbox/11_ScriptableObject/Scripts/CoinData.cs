using UnityEngine;

namespace Sandbox.Task11
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Sandbox/Task11/Coin Data")]
    public class CoinData : ScriptableObject
    {
        [SerializeField] private string _coinName;
        [SerializeField] private int _value;
        [SerializeField] private Color _color;

        public string CoinName => _coinName;
        public int Value => _value;
        public Color Color => _color;
    }
}


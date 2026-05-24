using UnityEngine;

namespace Sandbox.Task13
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Sandbox/Task13/Coin Data")]
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


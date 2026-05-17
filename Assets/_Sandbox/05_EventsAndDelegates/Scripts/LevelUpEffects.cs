using UnityEngine;

namespace Sandbox.Task05
{
    public class LevelUpEffects : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.OnLevelUp += PrintLevelStatus;
        }

        private void OnDisable()
        {
            _player.OnLevelUp -= PrintLevelStatus;
        }

        private void PrintLevelStatus(int level)
        {
            Debug.Log($"{_player.Name} повысил уровень! текущий уровень: {level}");
        }
    }
}


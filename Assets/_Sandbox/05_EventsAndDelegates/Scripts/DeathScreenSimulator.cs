using System;
using UnityEngine;

namespace Sandbox.Task05
{
    public class DeathScreenSimulator : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private void OnEnable()
        {
            _player.OnDied += PrintLifeStatus;
        }

        private void OnDisable()
        {
            _player.OnDied -= PrintLifeStatus;
        }

        private void PrintLifeStatus()
        {
            Debug.Log($"У {_player.Name} кончилось здоровье");
        }
    }
}


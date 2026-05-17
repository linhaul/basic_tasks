using UnityEngine;

namespace Sandbox.Task10
{
    public class PlayerInputLogger : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private void OnEnable()
        {
            _playerController.OnJumped += HandleJumped;
            _playerController.OnLanded += HandleLanded;
            _playerController.OnPaused += HandlePaused;
            _playerController.OnResumed += HandleResumed;
        }

        private void OnDisable()
        {
            _playerController.OnJumped -= HandleJumped;
            _playerController.OnLanded -= HandleLanded;
            _playerController.OnPaused -= HandlePaused;
            _playerController.OnResumed -= HandleResumed;
        }

        private void HandleJumped() => Debug.Log("Прыгнул");
        private void HandleLanded() => Debug.Log("Приземлился");
        private void HandlePaused() => Debug.Log("Включил паузу");
        private void HandleResumed() => Debug.Log("Возобновил игру");
    }
}

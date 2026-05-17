using UnityEngine;

namespace Sandbox.Task08
{
    public class PlayerEventLogger : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private void OnEnable()
        {
            _playerController.OnJumped += HandleJumped;
            _playerController.OnLanded += HandleLanded;
        }

        private void OnDisable()
        {
            _playerController.OnJumped -= HandleJumped;
            _playerController.OnLanded -= HandleLanded;
        }

        private void HandleJumped()
        {
            Debug.Log("Прыгнул");
        }

        private void HandleLanded()
        {
            Debug.Log("Приземлился");
        }
    }
}

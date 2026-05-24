using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Task13

{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public int Score { get; private set; }
        public GameState State { get; private set; }

        public event Action<GameState> OnGameStateChanged;
        public event Action<int> OnScoreChanged;


        [SerializeField] private PlayerHealth _playerHealth;
        private PlayerControls _controls;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            _controls = new PlayerControls();
            _controls.Gameplay.Pause.performed += OnPausePressed;
            _controls.Enable();
        }

        private void Start()
        {
            SetState(GameState.Playing);

            if (_playerHealth != null)
            {
                _playerHealth.OnDied += HandlePlayerDied;
            }
        }

        private void HandlePlayerDied()
        {
            SetState(GameState.GameOver);
        }

        public void AddScore(int amount)
        {
            Score += amount;
            OnScoreChanged?.Invoke(Score);
        }

        public void SetState(GameState newState)
        {
            State = newState;

            Time.timeScale = (State == GameState.Playing)
                ? 1f
                : 0f;

            OnGameStateChanged?.Invoke(State);
        }

        public void TogglePause()
        {
            if (State == GameState.GameOver) return;

            SetState(State == GameState.Playing 
                ? GameState.Paused 
                : GameState.Playing);
        }

        private void OnPausePressed(InputAction.CallbackContext ctx)
        {
            TogglePause();
        }

        private void OnDestroy()
        {
            if (Instance != this) return;

            if (_playerHealth != null)
            {
                _playerHealth.OnDied -= HandlePlayerDied;
            }

            _controls.Gameplay.Pause.performed -= OnPausePressed;
            _controls.Disable();
            _controls.Dispose();
        }
    }
}

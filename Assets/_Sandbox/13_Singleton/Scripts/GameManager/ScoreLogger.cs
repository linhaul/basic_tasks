using UnityEngine;

namespace Sandbox.Task13
{
    public class ScoreLogger : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
            GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
        }

        private void OnDisable()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
                GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
            }
        }

        private void HandleScoreChanged(int score) => Debug.Log($"Current score: {score}");
        private void HandleGameStateChanged(GameState state) => Debug.Log($"Current game state: {state}");
    }
}

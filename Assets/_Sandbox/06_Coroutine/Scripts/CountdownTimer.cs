using System;
using System.Collections;
using UnityEngine;

namespace Sandbox.Task06
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private int _startValue = 10;
        [SerializeField] private float _tickInterval = 1f;

        public bool IsRunning { get; private set; }
        public int CurrentValue { get; private set; }

        public event Action<int> OnTick;
        public event Action OnFinished;
        public event Action OnStopped;

        private Coroutine _timerCoroutine;

        private IEnumerator TimerRoutine()
        {
            IsRunning = true;
            CurrentValue = _startValue;

            WaitForSeconds wait = new WaitForSeconds(_tickInterval);

            while (CurrentValue > 0)
            {
                OnTick?.Invoke(CurrentValue);
                yield return wait;
                CurrentValue--;
            }

            IsRunning = false;
            _timerCoroutine = null;
            OnFinished?.Invoke();
        }

        public void StartTimer()
        {
            if (IsRunning) return;

            _timerCoroutine = StartCoroutine(TimerRoutine());
        }

        public void StopTimer()
        {
            if (!IsRunning) return;

            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
            IsRunning = false;

            OnStopped?.Invoke();
        }

        public void ResetTimer()
        {
            if (IsRunning) StopTimer();
            CurrentValue = 0;
        }

        private void OnDisable()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
                IsRunning = false;
            }
        }
    }
}

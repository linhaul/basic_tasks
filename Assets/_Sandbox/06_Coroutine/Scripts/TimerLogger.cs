using UnityEngine;

namespace Sandbox.Task06
{
    public class TimerLogger : MonoBehaviour
    {
        [SerializeField] private CountdownTimer _timer;

        private void OnEnable()
        {
            _timer.OnFinished += FinishedStatusHandler;
            _timer.OnStopped += StoppedStatusHandler;
            _timer.OnTick += TickStatusHandler;
        }

        private void OnDisable()
        {
            _timer.OnFinished -= FinishedStatusHandler;
            _timer.OnStopped -= StoppedStatusHandler;
            _timer.OnTick -= TickStatusHandler;
        }

        private void FinishedStatusHandler()
        {
            Debug.Log($"Время вышло!");
        }

        private void StoppedStatusHandler()
        {
            Debug.Log($"Таймер остановлен!");
        }

        private void TickStatusHandler(int tick)
        {
            Debug.Log($"Осталось: {tick}");
        }
    }
}

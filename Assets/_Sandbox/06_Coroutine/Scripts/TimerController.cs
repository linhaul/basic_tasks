using UnityEngine;

namespace Sandbox.Task06
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private CountdownTimer _timer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S)) _timer.StartTimer();
            if (Input.GetKeyDown(KeyCode.X)) _timer.StopTimer();
            if (Input.GetKeyDown(KeyCode.R)) _timer.ResetTimer();
        }
    }
}

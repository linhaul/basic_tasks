using System.Collections;
using UnityEngine;

namespace Sandbox.Task06
{
    public class SmoothValueChanger : MonoBehaviour
    {
        [SerializeField] private float _startValue = 0f;
        [SerializeField] private float _endValue = 100f;
        [SerializeField] private float _duration = 3f;
        public float CurrentValue { get; private set; }

        private Coroutine _transitionCoroutine;

        public void StartTransition()
        {
            _transitionCoroutine = StartCoroutine(TransitionRoutine());
        }

        private IEnumerator TransitionRoutine()
        {
            float elapsed = 0f;

            while (elapsed < _duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / _duration;

                CurrentValue = Mathf.Lerp(_startValue, _endValue, t);
                Debug.Log($"Value: {CurrentValue:F1}");
                yield return null;
            }

            CurrentValue = _endValue;
            _transitionCoroutine = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)) StartTransition();
        }
    }
}

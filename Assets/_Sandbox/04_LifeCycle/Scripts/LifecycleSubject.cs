using UnityEngine;

namespace Sandbox.Task04
{
    public class LifecycleSubject : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log($"[{name}] Awake - t={Time.time:F3}s");
        }

        private void OnEnable()
        {
            Debug.Log($"[{name}] OnEnable - t={Time.time:F3}s");
        }

        private void Start()
        {
            Debug.Log($"[{name}] Start - t={Time.time:F3}s");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)) Debug.Log($"[{name}] Update - t={Time.time:F3}s");
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.X)) Debug.Log($"[{name}] FixedUpdate - t={Time.time:F3}s");
        }

        private void OnDisable()
        {
            Debug.Log($"[{name}] OnDisable - t={Time.time:F3}s");
        }

        private void OnDestroy()
        {
            Debug.Log($"[{name}] OnDestroy - t={Time.time:F3}s");
        }
    }
}


using System.Collections.Generic;
using UnityEngine;

namespace Sandbox.Task04
{
    public class LifecycleController : MonoBehaviour
    {
        private List<LifecycleSubject> _spawnedSubjects = new List<LifecycleSubject>();
        private LifecycleSubject _current;
        private int _counter = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnSubject();
            if (Input.GetKeyDown(KeyCode.Alpha2)) DeactivateLast();
            if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateLast();
            if (Input.GetKeyDown(KeyCode.Alpha4)) DestroyLast();
        }

        private void SpawnSubject()
        {
            GameObject go = new GameObject($"Subject N{++_counter}");
            _current = go.AddComponent<LifecycleSubject>();
            _spawnedSubjects.Add(_current);
        }

        private void DeactivateLast()
        {
            LifecycleSubject last = GetLast();
            if (last == null) return;

            last.gameObject.SetActive(false);
        }

        private void ActivateLast()
        {
            LifecycleSubject last = GetLast();
            if (last == null) return;

            last.gameObject.SetActive(true);
        }

        private void DestroyLast()
        {
            LifecycleSubject last = GetLast();
            if (last == null) return;

            _spawnedSubjects.RemoveAt(_spawnedSubjects.Count - 1);
            Destroy(last.gameObject);
        }


        private LifecycleSubject GetLast() => _spawnedSubjects.Count == 0 ? null : _spawnedSubjects[^1];
    }
}


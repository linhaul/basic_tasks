using System;
using UnityEngine;

namespace Sandbox.Task07
{
    public class EnemySimple : MonoBehaviour
    {
        [SerializeField] private string _enemyType = "Goblin";
        //[SerializeField] private int _health = 30;
        [SerializeField] private int _reward = 5;
        [SerializeField] private float _lifetime = 8f;

        public static event Action<EnemySimple> OnAnyEnemySpawned;
        public static event Action<EnemySimple> OnAnyEnemyDefeated;
        public static event Action<EnemySimple> OnAnyEnemyDestroyed;

        public int Reward => _reward;
        public string EnemyType => _enemyType;

        private void Start()
        {
            Vector3 pos = gameObject.transform.position;
            OnAnyEnemySpawned?.Invoke( this );

            Destroy(gameObject, _lifetime);
        }

        public void Defeat()
        {
            OnAnyEnemyDefeated?.Invoke( this );
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnAnyEnemyDestroyed?.Invoke( this );
        }
    }
}


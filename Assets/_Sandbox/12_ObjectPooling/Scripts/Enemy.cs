using UnityEngine;

namespace Sandbox.Task12
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        [SerializeField] private int _maxHealth = 3;

        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;
        
        private EnemyPool _pool;

        public void SetPool(EnemyPool pool) => _pool = pool;

        public void OnSpawnFromPool()
        {
            CurrentHealth = _maxHealth;
        }

        public void OnReturnToPool()
        {
            //пока что пусто, если появятся корутины или события можно тут отписаться и т.п.
        }

        private void OnMouseDown()
        {
            Die();
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive) 
                return;

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);

            if (CurrentHealth == 0)
            {
                Die();
            }
        }   

        private void Die()
        {
            if (_pool != null)
            {
                _pool.Return(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

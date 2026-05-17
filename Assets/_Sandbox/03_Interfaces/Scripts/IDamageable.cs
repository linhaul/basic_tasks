using UnityEngine;

namespace Sandbox.Task03
{
    public interface IDamageable
    {
        int CurrentHealth { get; }
        bool IsAlive { get; }

        void TakeDamage(int damage);
    }
}

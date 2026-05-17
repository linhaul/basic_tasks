using UnityEngine;

namespace Sandbox.Task02
{
    public class Skeleton : Enemy
    {
        private bool _canResurrect = true;
        public Skeleton(string name) : base(name, 50, 15)
        {

        }

        public override void TakeDamage(int damage)
        {
            if (Health <= 0 && !_canResurrect)
            {
                Debug.Log($"{Name} Мертв!");
                return;
            }

            base.TakeDamage(damage);
        }

        protected override void OnDeath()
        {
            if (_canResurrect)
            {
                _canResurrect = false;
                Health = MaxHealth / 2;
                Debug.Log($"{Name} восстал из мёртвых! HP: {Health}");
            }
            else base.OnDeath();
        }
    }
}


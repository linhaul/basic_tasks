using UnityEngine;

namespace Sandbox.Task02
{
    public class Orc : Enemy
    {
        private const int _selfDamage = 10;
        public Orc(string name) : base(name, 150, 25)
        {

        }

        public override void Attack(Enemy target)
        {
            base.Attack(target);

            Debug.Log($"{Name} нанес себе увечья на {_selfDamage} ед. урона!");
            TakeDamage(_selfDamage);
        }
    }
}


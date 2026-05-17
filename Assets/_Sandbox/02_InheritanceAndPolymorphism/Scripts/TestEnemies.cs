using UnityEngine;

namespace Sandbox.Task02
{
    public class TestEnemies : MonoBehaviour
    {
        void Start()
        {
            Enemy[] enemies =
            {
            new Goblin("Гоблин"),
            new Orc("Орк"),
            new Skeleton("Скелет")
        };

            Dummy dummy = new Dummy("Манекен");

            foreach (Enemy enemy in enemies)
            {
                enemy.Attack(dummy);
                enemy.TakeDamage(50);
                enemy.TakeDamage(50);
                enemy.TakeDamage(1);
            }
        }
    }
}

using UnityEngine;

namespace Sandbox.Task01
{
    public class TestPlayer : MonoBehaviour
    {
        void Start()
        {
            Player player = new Player(100, "Steve");
            player.Status();

            player.TakeDamage(9999);
            player.Status();

            player.Heal(9999);
            player.Status();

            player.LevelUp();
            player.Status();
        }
    }
}

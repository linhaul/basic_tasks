using UnityEngine;

namespace Sandbox.Task05
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private int _damage = 20;
        [SerializeField] private int _heal = 15;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) _player.TakeDamage(_damage);
            if (Input.GetKeyDown(KeyCode.H)) _player.Heal(_heal);
            if (Input.GetKeyDown(KeyCode.L)) _player.LevelUp();
        }
    }
}

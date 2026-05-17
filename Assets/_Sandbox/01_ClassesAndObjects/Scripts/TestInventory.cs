using UnityEngine;

namespace Sandbox.Task01
{
    public class TestInventory : MonoBehaviour
    {
        void Start()
        {
            Inventory inventory = new Inventory("Steve", 100);

            inventory.AddItem(30);
            inventory.AddItem(40);
            inventory.AddItem(50);
            inventory.Status();
            inventory.RemoveItem(30);
            inventory.Status();
            inventory.Clear();
            inventory.Status();
            inventory.RemoveItem(10);
        }
    }
}


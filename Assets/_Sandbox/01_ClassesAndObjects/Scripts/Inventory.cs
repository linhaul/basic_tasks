using UnityEngine;

namespace Sandbox.Task01
{
    public class Inventory
    {
        public string HolderName { get; }
        public int MaxWeight { get; }
        public int CurrentWeight { get; private set; }
        public int ItemCount { get; private set; }

        public float FillPercent => (float)CurrentWeight / MaxWeight * 100f;

        public Inventory(string holderName, int maxWeight)
        {
            HolderName = holderName;
            MaxWeight = maxWeight;
            CurrentWeight = 0;
            ItemCount = 0;
        }

        public void AddItem(int itemWeight)
        {
            if (itemWeight < 0) return;

            if (CurrentWeight + itemWeight > MaxWeight)
            {
                Debug.Log($"Не смог добавить предмет, в инвентаре не хватает места: {CurrentWeight + itemWeight - MaxWeight}");
                return;
            }

            CurrentWeight += itemWeight;
            ItemCount++;
            Debug.Log($"Добавил предмет весом: {itemWeight}");
        }

        public void RemoveItem(int itemWeight)
        {
            if (itemWeight < 0) return;

            if (CurrentWeight == 0)
            {
                Debug.Log("Инвентарь пуст");
                return;
            }

            if (CurrentWeight < itemWeight)
            {
                Debug.Log("Предмета с таким весом в инвентаре нет");
                return;
            }

            CurrentWeight -= itemWeight;
            ItemCount--;
            Debug.Log($"Удалил предмет весом: {itemWeight}");
        }

        public void Clear()
        {
            CurrentWeight = 0;
            ItemCount = 0;
        }

        public void Status()
        {
            Debug.Log($"Текущий вес: {CurrentWeight}/{MaxWeight}, Заполненность: {FillPercent}%, Количество предметов: {ItemCount}");
        }
    }
}

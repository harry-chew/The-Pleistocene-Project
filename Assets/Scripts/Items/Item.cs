using System;

namespace TPP.Scripts.Items
{
    [Serializable]
    public class Item
    {
        public string itemName;
        public int weight;
        public int quantity;

        public Item(string itemName, int weight, int quantity)
        {
            this.itemName = itemName;
            this.weight = weight;
            this.quantity = quantity;
        }
    }
}

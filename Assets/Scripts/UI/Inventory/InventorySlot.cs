using TMPro;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class InventorySlot : MonoBehaviour
    {
        public TextMeshProUGUI itemCount;

        public Item item;

        public void Init(Item item)
        {
            this.item = item;
            itemCount.text = item.quantity.ToString();
        }

        public void UpdateQuantity(int quantity)
        {
            item.quantity += quantity;
            itemCount.text = item.quantity.ToString();
        }
    }
}

using TMPro;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP
{
    public class InventorySlot : MonoBehaviour
    {
        public TextMeshProUGUI itemCount;

        public Item item;

        public void Init(int quantity)
        {
            itemCount.text = quantity.ToString();
        }
    }
}

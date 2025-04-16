using System;
using UnityEngine;

namespace TPP.Scripts.Items
{
    [Serializable]
    public class Item
    {
        public string itemName;
        public int weight;
        public int quantity;
        public AudioClip interactClip;
        public Sprite icon;

        public Item(string itemName, int weight, int quantity)
        {
            this.itemName = itemName;
            this.weight = weight;
            this.quantity = quantity;
        }

        public Item(ItemSO itemSO)
        {
            itemName = itemSO.itemName;
            weight = itemSO.weight;
            quantity = itemSO.quantity;
            interactClip = itemSO.interactClip;
            icon = itemSO.icon;
        }
    }
}

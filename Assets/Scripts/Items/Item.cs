using System;
using TPP.Scripts.Interactable;
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
        public GameObject itemPrefab;
        public CollectItemInteractable interactableItem;

        public Item(ItemSO itemSO)
        {
            itemName = itemSO.itemName;
            weight = itemSO.weight;
            quantity = itemSO.quantity;
            interactClip = itemSO.interactClip;
            icon = itemSO.icon;
            itemPrefab = itemSO.itemPrefab;
            interactableItem = itemSO.interactableItem;
        }
    }
}

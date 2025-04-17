using System.Collections.Generic;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<Item> items = new List<Item>();

        private void Start()
        {
            CoreEvents.ItemEvent += OnItemEvent;
        }

        private void OnDestroy()
        {
            CoreEvents.ItemEvent -= OnItemEvent;
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Collect)
            {
                if (e.item == null)
                    return;

                Item item = new Item(e.item);
                AddItem(item);
            }
            else if (e.eventType == ItemEventType.Use)
            {
                if (e.item == null)
                    return;

                Item item = new Item(e.item);
                ReduceItemQuantity(item);
            }
        }

        private void ReduceItemQuantity(Item item)
        {
            if (items == null || items.Count == 0)
                return;

            Item itemToRemove = null;
            foreach (Item loopItem in items)
            {
                if (item.itemName == loopItem.itemName)
                {
                    loopItem.quantity -= item.quantity;
                    if (loopItem.quantity <= 0)
                    {
                        itemToRemove = loopItem;
                        break;
                    }
                }
            }

            items.Remove(itemToRemove);
        }

        private void AddItem(Item itemToAdd)
        {
            if (items == null || items.Count == 0)
            {
                items.Add(itemToAdd);
                return;
            }

            foreach (Item loopItem in items)
            {
                if (loopItem.itemName == itemToAdd.itemName)
                {
                    loopItem.quantity += itemToAdd.quantity;
                    return;
                }
            }

            items.Add(itemToAdd);
        }

        private void RemoveItem(Item itemToRemove)
        {
            if (items == null || items.Count == 0)
                return;

            foreach (Item loopItem in items)
            {
                if (loopItem.itemName == itemToRemove.itemName)
                {
                    items.Remove(loopItem);
                    break;
                }
            }
        }
    }
}

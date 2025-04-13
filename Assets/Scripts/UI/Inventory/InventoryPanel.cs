using System;
using System.Collections.Generic;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        public InventorySlot inventorySlotPrefab;

        private List<InventorySlot> inventorySlots = new List<InventorySlot>();

        private void OnEnable()
        {
            CoreEvents.ItemEvent += OnItemEvent;
        }

        private void OnDisable()
        {
            CoreEvents.ItemEvent -= OnItemEvent;
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Collect)
            {
                if (!HasInventoryItem(e.item))
                {
                    InventorySlot slot = Instantiate(inventorySlotPrefab, transform);
                    slot.item = e.item;
                    slot.Init(slot.item.quantity);
                    inventorySlots.Add(slot);
                }
                else
                {
                    InventorySlot slot = GetInventorySlot(e.item);
                    if (slot == null)
                        return;

                    slot.item.quantity += e.item.quantity;
                    slot.Init(slot.item.quantity);
                }
            }
        }

        private bool HasInventoryItem(Item item)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return false;

            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.item.itemName == item.itemName)
                {
                    return true;
                }
            }

            return false;
        }

        private InventorySlot GetInventorySlot(Item item)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return null;

            foreach (InventorySlot slot in inventorySlots)
            {
                if (slot.item.itemName == item.itemName)
                {
                    return slot;
                }
            }

            return null;
        }
    }
}

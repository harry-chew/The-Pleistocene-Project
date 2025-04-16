using System;
using System.Collections.Generic;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class InventoryPanel : MonoBehaviour
    {
        [Header("Slot Prefab")]
        public InventorySlot inventorySlotPrefab;

        [Space(10)]
        [Header("Properties")]
        [Range(1, 8)]
        public int maxSlots;

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
                if (inventorySlots == null)
                    inventorySlots = new List<InventorySlot>();

                Item item = new Item(e.item);
                if (!HasInventoryItem(item) && inventorySlots.Count < maxSlots)
                {
                    InventorySlot slot = Instantiate(inventorySlotPrefab, transform);
                    slot.Init(item);
                    inventorySlots.Add(slot);
                }
                else
                {
                    InventorySlot slot = GetInventorySlot(item);
                    if (slot == null)
                        return;

                    slot.UpdateQuantity(e.item.quantity);
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectSlot(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectSlot(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectSlot(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectSlot(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectSlot(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectSlot(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectSlot(6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SelectSlot(7);
            }
        }

        private void SelectSlot(int index)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return;

            for (int i = 0; i < inventorySlots.Count; i++)
            {
                inventorySlots[i].SelectSlot(index == i);
            }
        }
    }
}

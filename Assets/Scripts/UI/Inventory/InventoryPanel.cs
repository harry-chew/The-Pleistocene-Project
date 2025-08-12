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

        private int selectedIndex = -1;
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
                HandleCollectItem(e);
            }
            else if (e.eventType == ItemEventType.Use)
            {
                HandleUseItem(e);
            }
        }

        private void HandleUseItem(ItemEventArgs e)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return;

            Item item = new Item(e.item);
            if (HasInventoryItem(item))
            {
                InventorySlot slot = GetInventorySlot(item);
                if (slot == null)
                    return;

                slot.UpdateQuantity(-e.item.quantity);
                if (slot.item.quantity <= 0)
                {
                    DeselectSlot(slot);
                    inventorySlots.Remove(slot);
                    Destroy(slot.gameObject);
                }
            }
        }

        private void HandleCollectItem(ItemEventArgs e)
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

        private bool IsSelected(int index)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
            {
                return false;
            }

            if (inventorySlots[index] != null)
            {
                return inventorySlots[index].selected;
            }

            return false;
        }

        private void SelectSlot(int index)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return;

            if (index >= inventorySlots.Count)
                return;

            if (IsSelected(index))
            {
                DeselectSlot(index);
                return;
            }

            if (selectedIndex != index && selectedIndex != -1)
                DeselectSlot(selectedIndex);

            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (index == i)
                {
                    inventorySlots[i].SelectSlot(index == i);
                    CoreEvents.FirePlayerSelectedItemEvent(inventorySlots[i].item);
                }
            }

            selectedIndex = index;
        }

        private void DeselectSlot(int index)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return;

            if (inventorySlots[index] != null)
            {
                inventorySlots[index].SelectSlot(false);
                selectedIndex = -1;
                CoreEvents.FirePlayerSelectedItemEvent(null);
            }
        }

        private void DeselectSlot(InventorySlot slot)
        {
            if (inventorySlots == null || inventorySlots.Count == 0)
                return;

            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i] == slot)
                {
                    DeselectSlot(i);
                }
            }
        }
    }
}

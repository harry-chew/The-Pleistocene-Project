using System;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerSelectedItem : MonoBehaviour
    {
        public Transform handsPosition;
        public GameObject selectedItem;

        public void Start()
        {
            CoreEvents.SelectedItemEvent += OnItemEvent;
        }

        private void OnItemEvent(Item item)
        {
            if (selectedItem == null && item != null)
            {
                selectedItem = Instantiate(item.itemPrefab, handsPosition.position, Quaternion.identity, handsPosition);
            }
            else if (selectedItem != null && item == null)
            {
                Destroy(selectedItem);
                selectedItem = null;
            }
        }
    }
}

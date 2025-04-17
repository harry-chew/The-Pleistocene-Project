using DG.Tweening;
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

        public Item item;

        public void OnEnable()
        {
            CoreEvents.SelectedItemEvent += OnSelectedItemEvent;
            CoreEvents.ItemEvent += OnItemEvent;
        }

        public void OnDisable()
        {
            CoreEvents.SelectedItemEvent += OnSelectedItemEvent;
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Use)
            {
                if (selectedItem == null)
                    return;

                float scale = selectedItem.transform.localScale.y;

                Sequence anim = DOTween.Sequence(selectedItem);
                anim.Append(selectedItem.transform.DOScale(scale * 1.25f, 0.1f));
                anim.Append(selectedItem.transform.DOScale(scale, 0.2f));
                anim.Play();
            }
        }

        private void OnSelectedItemEvent(Item item)
        {
            this.item = item;

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

        private void Update()
        {
            if (item == null || item.interactableItem == null)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                item.interactableItem.Primary();
            }
        }
    }
}

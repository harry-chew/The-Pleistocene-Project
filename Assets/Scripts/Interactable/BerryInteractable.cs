using System;
using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class BerryInteractable : CollectItemInteractable
    {
        public GameObject berries;
        public bool canInteract;

        private void Awake()
        {
            canInteract = true;
        }

        private void Start()
        {
            CoreEvents.WorldEvent += OnWorldEvent;
        }

        private void OnDestroy()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
        }

        private void OnWorldEvent(object sender, WorldEventArgs e)
        {
            if (e.eventType == WorldEventType.HourTick)
            {
                if (canInteract)
                    return;

                canInteract = true;
                berries.SetActive(true);
            }
        }

        public override void Interact()
        {
            if (canInteract)
            {
                base.Interact();
                canInteract = false;
                berries.SetActive(false);
            }
        }
    }
}

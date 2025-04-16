using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class BerryInteractable : CollectItemInteractable
    {
        public GameObject berries;
        public bool canInteract;

        private void Start()
        {
            CoreEvents.WorldEvent += OnWorldEvent;
        }

        private void OnDestroy()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
        }

        private void Awake()
        {
            canInteract = true;
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

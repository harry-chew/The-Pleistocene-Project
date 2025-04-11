using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class MushroomInteractable : AbstractInteractable, IInteractable
    {
        public Item item;

        public override void Interact()
        {
            Debug.Log($"interact on {transform.name}");
            CoreEvents.FirePlayerCollectItemEvent(item);
            Destroy(gameObject);
        }
    }
}

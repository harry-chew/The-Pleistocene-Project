using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class MushroomInteractable : CollectItemInteractable
    {
        public override void Interact()
        {
            base.Interact();

            Destroy(gameObject);
        }
    }
}

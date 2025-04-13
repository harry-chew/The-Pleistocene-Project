using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class CollectItemInteractable : AbstractInteractable
    {
        public Item item;

        public override void Interact()
        {
            if (item == null)
            {
                Debug.LogError("You must set the item that will be picked up");
                return;
            }

            Debug.Log($"interact on {transform.name}");
            Item copied = new Item(item.itemName, item.weight, item.quantity);
            CoreEvents.FirePlayerCollectItemEvent(copied);
            Destroy(gameObject);
        }
    }
}

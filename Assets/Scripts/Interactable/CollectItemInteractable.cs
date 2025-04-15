using TPP.Scripts.Events;
using TPP.Scripts.Items;
using UnityEngine;

namespace TPP.Scripts.Interactable
{
    public class CollectItemInteractable : AbstractInteractable
    {
        public ItemSO itemSO;

        public override void Interact()
        {
            if (itemSO == null)
            {
                Debug.LogError("You must set the item that will be picked up");
                return;
            }

            Debug.Log($"interact on {transform.name}");
            CoreEvents.FirePlayerCollectItemEvent(itemSO);
        }
    }
}

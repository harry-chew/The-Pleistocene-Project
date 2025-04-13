using System;
using TPP.Scripts.Interactable;
using TPP.Scripts.Items;

namespace TPP.Scripts.Events
{
    public class CoreEvents
    {
        public static Action<IInteractable> SelectInteractableEvent;

        public static EventHandler<ItemEventArgs> ItemEvent;
        public static EventHandler<WorldEventArgs> WorldEvent;

        public static void FireSelectInteractableEvent(IInteractable interactable)
        {
            SelectInteractableEvent?.Invoke(interactable);
        }

        public static void FirePlayerCollectItemEvent(Item item)
        {
            ItemEventArgs args = new ItemEventArgs(ItemEventType.Collect, item);
            ItemEvent?.Invoke(null, args);
        }

        public static void FireWorldTickEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.Tick);
            WorldEvent?.Invoke(null, args);
        }
    }
}

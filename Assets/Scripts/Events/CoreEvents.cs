using System;
using TPP.Scripts.Interactable;

namespace TPP.Scripts.Events
{
    public class CoreEvents
    {
        public static Action<IInteractable> SelectInteractable;

        public static void FireSelectInteractableEvent(IInteractable interactable)
        {
            SelectInteractable?.Invoke(interactable);
        }
    }
}

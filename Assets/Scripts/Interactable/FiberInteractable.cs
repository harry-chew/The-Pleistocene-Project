using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class FiberInteractable : CollectItemInteractable
    {
        public override void Interact()
        {
            base.Interact();

            Destroy(gameObject);
        }
    }
}

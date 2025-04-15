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

namespace TPP.Scripts.Interactable
{
    public class RockInteractable : CollectItemInteractable
    {
        public override void Interact()
        {
            base.Interact();
            Destroy(gameObject);
        }
    }
}

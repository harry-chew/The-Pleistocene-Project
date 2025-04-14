using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class RockInteractable : CollectItemInteractable
    {
        private void Start()
        {
            item = ItemFactory.CreateRockItem();
        }

        public override void Interact()
        {
            base.Interact();
            Destroy(gameObject);
        }
    }
}

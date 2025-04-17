using TPP.Scripts.Flora;

namespace TPP.Scripts.Interactable
{
    public class StickInteractable : CollectItemInteractable
    {
        private LivingTree tree;

        public void Init(LivingTree tree = null)
        {
            this.tree = tree;    
        }

        public override void Interact()
        {
            base.Interact();

            if (tree != null)
            {
                tree.RemoveStick(this);
                tree = null;
            }

            Destroy(gameObject);
        }
    }
}

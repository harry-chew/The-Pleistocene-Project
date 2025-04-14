using TPP.Scripts.Flora;
using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class StickInteractable : CollectItemInteractable
    {
        private LivingTree tree;

        void Start()
        {
            item = ItemFactory.CreateWoodStickItem();
        }

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
            }

            Destroy(gameObject);
        }
    }
}

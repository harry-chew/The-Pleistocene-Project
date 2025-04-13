using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class FiberInteractable : CollectItemInteractable
    {
        private void Start()
        {
            item = ItemFactory.CreateFiberItem();
        }
    }
}

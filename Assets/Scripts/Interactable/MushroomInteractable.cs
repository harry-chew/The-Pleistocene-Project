using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class MushroomInteractable : CollectItemInteractable
    {
        private void Start()
        {
            item = ItemFactory.CreateMushroomItem();
        }
    }
}

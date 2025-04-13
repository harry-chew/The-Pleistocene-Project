using TPP.Scripts.Items;

namespace TPP.Scripts.Interactable
{
    public class StickInteractable : CollectItemInteractable
    {
        void Start()
        {
            item = ItemFactory.CreateWoodStickItem();
        }
    }
}

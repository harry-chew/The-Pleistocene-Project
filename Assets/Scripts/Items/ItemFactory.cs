namespace TPP.Scripts.Items
{
    public class ItemFactory
    {
        public static Item CreateMushroomItem()
        {
            Item mushroom = new Item("Mushroom", 1, 1);

            return mushroom;
        }

        public static Item CreateWoodStickItem()
        {
            Item stick = new Item("Stick", 1, 1);

            return stick;
        }
    }
}

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

        public static Item CreateFiberItem()
        {
            Item fiber = new Item("Fiber", 1, 1);

            return fiber;
        }

        public static Item CreateBerryItem()
        {
            Item berries = new Item("Berries", 1, 5);

            return berries;
        }
    }
}

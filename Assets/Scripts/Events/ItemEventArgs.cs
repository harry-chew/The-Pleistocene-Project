using System;
using TPP.Scripts.Items;

namespace TPP.Scripts.Events
{
    public enum ItemEventType
    {
        Collect
    }

    public class ItemEventArgs : EventArgs
    {
        public ItemEventType eventType;
        public Item item;

        public ItemEventArgs(ItemEventType eventType, Item item)
        {
            this.eventType = eventType;
            this.item = item;
        }
    }
}

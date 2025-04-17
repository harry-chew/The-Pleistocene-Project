using System;
using TPP.Scripts.Items;

namespace TPP.Scripts.Events
{
    public enum ItemEventType
    {
        Collect,
        Use
    }

    public class ItemEventArgs : EventArgs
    {
        public ItemEventType eventType;
        public ItemSO item;

        public ItemEventArgs(ItemEventType eventType, ItemSO item)
        {
            this.eventType = eventType;
            this.item = item;
        }
    }
}

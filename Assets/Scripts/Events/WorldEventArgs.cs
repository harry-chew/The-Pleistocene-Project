﻿using System;

namespace TPP.Scripts.Events
{
    public enum WorldEventType
    {
        Tick,
        HourTick,
        DayTick
    }

    public class WorldEventArgs : EventArgs
    {
        public WorldEventType eventType;

        public WorldEventArgs(WorldEventType eventType)
        {
            this.eventType = eventType;
        }
    }
}

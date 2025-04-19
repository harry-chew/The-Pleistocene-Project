using System;

namespace TPP.Scripts.Events
{
    public class PlayerEventArgs : EventArgs
    {
        public float hunger;
        public float thirst;
        public float temperature;

        public PlayerEventArgs(float hunger, float thirst, float temperature)
        {
            this.hunger = hunger;
            this.thirst = thirst;
            this.temperature = temperature;
        }
    }
}

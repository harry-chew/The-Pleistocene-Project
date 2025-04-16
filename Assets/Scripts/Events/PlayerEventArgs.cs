using System;

namespace TPP.Scripts.Events
{
    public class PlayerEventArgs : EventArgs
    {
        public int hunger;
        public int thirst;
        public float temperature;

        public PlayerEventArgs(int hunger, int thirst, float temperature)
        {
            this.hunger = hunger;
            this.thirst = thirst;
            this.temperature = temperature;
        }
    }
}

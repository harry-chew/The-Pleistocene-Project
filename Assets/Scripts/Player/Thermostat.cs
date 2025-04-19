using TPP.Scripts.Environment;
using TPP.Scripts.Systems;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class Thermostat : MonoBehaviour, IHeatable
    {
        [SerializeField] private float temperature;

        public void Init(float temperature)
        {
            this.temperature = temperature;
        }

        public float GetCurrentTemperature()
        {
            return temperature;
        }

        public void Heat(float heatStrength)
        {
            temperature += heatStrength;
        }

        public void Tick()
        {
            if (!DayNightCycle.IsDayTime())
                temperature -= 0.75f;
            else
                temperature += 0.25f;
        }
    }
}

using TPP.Scripts.Environment;
using TPP.Scripts.Events;
using TPP.Scripts.Systems;
using UnityEngine;

namespace TPP.Scripts
{
    public class PlayerStats : MonoBehaviour, IHeatable
    {
        [Header("Hunger")]
        public int hunger;
        public int startingHunger;

        [Header("Thirst")]
        public int thirst;
        public int startingThirst;

        [Header("Temperature")]
        public float temperature;
        public float startingTemperature;

        private void Awake()
        {
            hunger = startingHunger;
            thirst = startingThirst;
            temperature = startingTemperature;
        }

        private void OnEnable()
        {
            CoreEvents.WorldEvent += OnWorldEvent;
        }

        private void OnDisable()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
        }

        private void OnWorldEvent(object sender, WorldEventArgs e)
        {
            if (e.eventType == WorldEventType.Tick)
            {
                hunger--;
                thirst--;

                HandleTemperature();
            }
        }

        private void HandleTemperature()
        {
            if (!DayNightCycle.IsDayTime())
                temperature -= 0.75f;
            else
                temperature += 0.25f;
        }

        public void Heat(int heatStrength)
        {
            temperature += heatStrength;
            Debug.Log(temperature);
        }
    }
}

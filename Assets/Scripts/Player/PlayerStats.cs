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
            CoreEvents.DrinkWaterEvent += OnDrinkWaterEvent;
            CoreEvents.ItemEvent += OnItemEvent;
        }

        private void OnDisable()
        {
            CoreEvents.WorldEvent -= OnWorldEvent;
            CoreEvents.DrinkWaterEvent -= OnDrinkWaterEvent;
            CoreEvents.ItemEvent -= OnItemEvent;
        }

        private void OnWorldEvent(object sender, WorldEventArgs e)
        {
            if (e.eventType == WorldEventType.Tick)
            {
                HandleHunger();
                HandleThirst();
                HandleTemperature();

                CoreEvents.FirePlayerStatsEvent(hunger, thirst, temperature);
            }
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Use)
            {
                if (e.item.itemName == "Edible Mushroom")
                {
                    hunger += 10;
                    CoreEvents.FirePlayerStatsEvent(hunger, thirst, temperature);
                }
            }
        }

        private void OnDrinkWaterEvent(int waterAmount)
        {
            thirst += waterAmount;
            if (thirst >= startingThirst)
                thirst = startingThirst;

            CoreEvents.FirePlayerStatsEvent(hunger, thirst, temperature);
        }

        private void HandleTemperature()
        {
            if (!DayNightCycle.IsDayTime())
                temperature -= 0.75f;
            else
                temperature += 0.25f;
        }

        private void HandleHunger()
        {
            hunger--;
        }

        private void HandleThirst()
        {
            thirst--;
        }

        public void Heat(int heatStrength)
        {
            temperature += heatStrength;
            Debug.Log(temperature);
        }
    }
}

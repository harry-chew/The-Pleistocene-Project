using TPP.Scripts.Defines;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public Metabolism metabolism;
        public Hydration hydration;
        public Thermostat thermostat;

        private void Awake()
        {
            metabolism.Init(100f);
            hydration.Init(100f);
            thermostat.Init(37f);
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
            if (e.eventType == WorldEventType.HourTick)
            {
                metabolism.Tick();
                hydration.Tick();
                thermostat.Tick();

                CoreEvents.FirePlayerStatsEvent(metabolism.GetSated(), hydration.GetHydrationLevel(), thermostat.GetCurrentTemperature());
            }
        }

        private void OnItemEvent(object sender, ItemEventArgs e)
        {
            if (e.eventType == ItemEventType.Use)
            {
                if (e.item.itemName == ItemDefines.EdibleMushroomItemName)
                {
                    metabolism.Eat(10);
                    CoreEvents.FirePlayerStatsEvent(metabolism.GetSated(), hydration.GetHydrationLevel(), thermostat.GetCurrentTemperature());
                }
            }
        }

        private void OnDrinkWaterEvent(int waterAmount)
        {
            hydration.Hydrate(waterAmount);

            CoreEvents.FirePlayerStatsEvent(metabolism.GetSated(), hydration.GetHydrationLevel(), thermostat.GetCurrentTemperature());
        }
    }
}

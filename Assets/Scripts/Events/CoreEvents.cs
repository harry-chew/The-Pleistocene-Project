using System;
using TPP.Scripts.Interactable;
using TPP.Scripts.Items;

namespace TPP.Scripts.Events
{
    public class CoreEvents
    {
        public static Action<IInteractable> SelectInteractableEvent;

        public static EventHandler<ItemEventArgs> ItemEvent;
        public static Action<Item> SelectedItemEvent; 
        public static EventHandler<WorldEventArgs> WorldEvent;
        public static EventHandler<PlayerEventArgs> PlayerEvent;
        public static Action<int> DrinkWaterEvent;
        public static EventHandler<WeatherEventArgs> WeatherEvent;

        public static void FireSelectInteractableEvent(IInteractable interactable)
        {
            SelectInteractableEvent?.Invoke(interactable);
        }

        public static void FirePlayerCollectItemEvent(ItemSO item)
        {
            ItemEventArgs args = new ItemEventArgs(ItemEventType.Collect, item);
            ItemEvent?.Invoke(null, args);
        }

        public static void FirePlayerUseItemEvent(ItemSO item)
        {
            ItemEventArgs args = new ItemEventArgs(ItemEventType.Use, item);
            ItemEvent?.Invoke(null, args);
        }

        public static void FirePlayerSelectedItemEvent(Item item)
        {
            SelectedItemEvent?.Invoke(item);
        }

        public static void FireWorldTickEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.Tick);
            WorldEvent?.Invoke(null, args);
        }

        public static void FireWorldTickHourEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.HourTick);
            WorldEvent?.Invoke(null, args);
        }

        public static void FireWorldTickDayEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.DayTick);
            WorldEvent?.Invoke(null, args);
        }

        public static void FireWorldTickWeekEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.WeekTick);
            WorldEvent?.Invoke(null, args);
        }

        public static void FireWorldTickMonthEvent()
        {
            WorldEventArgs args = new WorldEventArgs(WorldEventType.MonthTick);
            WorldEvent?.Invoke(null, args);
        }

        public static void FirePlayerStatsEvent(float hunger, float thirst, float temperature)
        {
            PlayerEventArgs args = new PlayerEventArgs(hunger, thirst, temperature);
            PlayerEvent?.Invoke(null, args);
        }

        public static void FireDrinkWaterEvent(int waterAmount)
        {
            DrinkWaterEvent?.Invoke(waterAmount);
        }

        public static void FireWeatherChangedEvent(float temperature, float windSpeed, float windDirection)
        {
            WeatherChangedEventArgs args = new WeatherChangedEventArgs(temperature, windSpeed, windDirection);
            WeatherEvent?.Invoke(null, args);
        }
    }
}

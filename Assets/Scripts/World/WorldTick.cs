using TPP.Scripts.Events;
using TPP.Scripts.Systems;
using UnityEngine;

namespace TPP.Scripts.World
{
    public class WorldTick : MonoBehaviour
    {
        [Header("Properties")]
        public float tickTimer;
        public float dayNightCycleMultiplier;
        public float currentTick;
        public int ticks;

        private void Start()
        {
            dayNightCycleMultiplier = DayNightCycle.DayNightRateMultiplier;
            tickTimer = dayNightCycleMultiplier;
        }

        private void Update()
        {
            currentTick += Time.deltaTime;
            if (currentTick >= tickTimer)
            {
                CoreEvents.FireWorldTickHourEvent();
                ticks++;
                currentTick = 0f;

                // 24 ticks per day, 168 ticks per week, 672 ticks per month
                if (ticks % 24 == 0)
                {
                    CoreEvents.FireWorldTickDayEvent();
                }

                if (ticks % 168 == 0)
                {
                    CoreEvents.FireWorldTickWeekEvent();
                }

                if (ticks % 672 == 0)
                {
                    CoreEvents.FireWorldTickMonthEvent();
                    ticks = 0;
                }
            }
        }
    }
}

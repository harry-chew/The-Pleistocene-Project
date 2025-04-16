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
                CoreEvents.FireWorldTickEvent();
                ticks++;
                currentTick = 0f;

                if (ticks % 60 == 0)
                {
                    CoreEvents.FireWorldTickHourEvent();
                }
                if (ticks % 60 * 24 == 0)
                {
                    CoreEvents.FireWorldTickDayEvent();
                    ticks = 0;
                }
            }
        }
    }
}

using System.Collections;
using TPP.Scripts.Events;
using TPP.Scripts.Systems;
using UnityEngine;

namespace TPP.Scripts.World
{
    public class WorldTick : MonoBehaviour
    {
        public float tickTimer;
        public float dayNightCycleMultiplier;
        public float currentTick;

        private void Start()
        {
            dayNightCycleMultiplier = DayNightCycle.DayNightRateMultiplier;
            tickTimer = dayNightCycleMultiplier / 24f;
        }

        private void Update()
        {
            currentTick += Time.deltaTime;
            if (currentTick >= tickTimer)
            {
                CoreEvents.FireWorldTickEvent();
                Debug.Log("tick");
                currentTick = 0f;
            }
        }
    }
}

using System;
using System.Collections;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Hunger")]
        public int hunger;
        public int startingHunger;

        [Header("Thirst")]
        public int thirst;
        public int startingThirst;

        private void Awake()
        {
            hunger = startingHunger;
            thirst = startingThirst;
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
            }
        }
    }
}

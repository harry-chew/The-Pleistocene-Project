using System;
using TPP.Scripts.Events;
using TPP.Scripts.UI.Components;
using UnityEngine;

namespace TPP.Scripts.UI
{
    public class PlayerStatsPanel : MonoBehaviour
    {
        public PlayerStatsComponent hungerComponent;
        public PlayerStatsComponent thirstComponent;
        public PlayerStatsComponent temperatureComponent;

        public void Start()
        {
            hungerComponent.Init();
            thirstComponent.Init();
            temperatureComponent.Init();

            CoreEvents.PlayerEvent += OnPlayerEvent;
        }

        private void OnPlayerEvent(object sender, PlayerEventArgs e)
        {
            hungerComponent.UpdateValue(e.hunger);
            thirstComponent.UpdateValue(e.thirst);
            temperatureComponent.UpdateValue(Mathf.RoundToInt(e.temperature));
        }
    }
}

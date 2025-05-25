using System;
using TPP.Scripts.Events;
using UnityEngine;

namespace TPP.Scripts.Systems.Weather
{
    public class WeatherSystem : MonoBehaviour
    {
        public static WeatherSystem Instance { get; private set; }

        public float ambientTemperature = 20f; // Default ambient temperature in degrees Celsius
        public float windSpeed = 5f; // Default wind speed in m/s
        public float windDirection = 0f; // Wind direction in degrees (0 = North, 90 = East, 180 = South, 270 = West)

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Debug.Log("Weather System Initialized with Ambient Temperature: " + ambientTemperature + "°C");
            Debug.Log("Initial Wind Speed: " + windSpeed + " m/s, Direction: " + windDirection + "°");

            CoreEvents.FireWeatherChangedEvent(ambientTemperature, windSpeed, windDirection);
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
            if (e.eventType == WorldEventType.HourTick)
            {
                UpdateTemperature();
                UpdateWind();

                CoreEvents.FireWeatherChangedEvent(ambientTemperature, windSpeed, windDirection);
            }
        }

        private void UpdateWind()
        {
            windSpeed += UnityEngine.Random.Range(-0.5f, 0.5f); // Randomly adjust wind speed
            windDirection += UnityEngine.Random.Range(-5f, 5f); // Randomly adjust wind direction

            // Normalize direction
            if (windDirection < 0) 
                windDirection += 360; 

            else if (windDirection >= 360)
                windDirection -= 360;
        }

        private void UpdateTemperature()
        {
            if (DayNightCycle.IsMorning())
            {
                ambientTemperature += UnityEngine.Random.Range(0.5f, 1f); // Slightly warmer in the morning
            }
            else if (DayNightCycle.IsAfternoon())
            {
                ambientTemperature += UnityEngine.Random.Range(1f, 2f); ; // Warmest in the afternoon
            }
            else if (DayNightCycle.IsEvening())
            {
                ambientTemperature -= UnityEngine.Random.Range(1f, 0.25f); // Cooling down in the evening
            }
            else if (DayNightCycle.IsNightTime())
            {
                ambientTemperature -= UnityEngine.Random.Range(2f, 1f); // Coldest at night
            }
        }
    }
}

using TMPro;
using TPP.Scripts.Events;
using UnityEngine;
using UnityEngine.UI;

namespace TPP.Scripts.UI.StatusBarPanel
{
    public class WeatherInformationPanel : MonoBehaviour
    {
        [Header("Weather Information")]
        public Image weatherIcon;
        public TextMeshProUGUI temperatureText;

        [Header("Wind Information")]
        public Image windDirectionIcon;
        public TextMeshProUGUI windSpeedText;

        private void OnEnable()
        {
            CoreEvents.WeatherEvent += OnWeatherEvent;
        }

        private void OnDisable()
        {
            CoreEvents.WeatherEvent -= OnWeatherEvent;
        }

        private void OnWeatherEvent(object sender, WeatherEventArgs e)
        {
            if (e.EventType == WeatherEventType.WeatherChanged)
            {
                WeatherChangedEventArgs weatherChangedEventArgs = (WeatherChangedEventArgs)e;
                if (weatherChangedEventArgs == null)
                    return;

                UpdateWeatherInformation(weatherChangedEventArgs.Temperature, weatherChangedEventArgs.WindSpeed, weatherChangedEventArgs.WindDirection);
            }
        }

        private void UpdateWeatherInformation(float temperature, float windSpeed, float windDirection)
        {
            temperatureText.text = $"{temperature:0} °C";
            windSpeedText.text = $"{windSpeed:0} m/s";
            windDirectionIcon.transform.rotation = Quaternion.Euler(0, 0, windDirection);
        }
    }
}

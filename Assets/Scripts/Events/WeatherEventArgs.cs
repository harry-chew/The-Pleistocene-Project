using System;

namespace TPP.Scripts.Events
{
    public enum WeatherEventType
    {
        WeatherChanged,
        WeatherForecastUpdated,
        SevereWeatherAlert
    }

    public class WeatherEventArgs : EventArgs
    {
        public WeatherEventType EventType { get; private set; }
        public WeatherEventArgs(WeatherEventType eventType)
        {
            EventType = eventType;
        }
    }

    public class WeatherChangedEventArgs : WeatherEventArgs
    {
        public float Temperature { get; private set; }
        public float WindSpeed { get; private set; }
        public float WindDirection { get; private set; }

        public WeatherChangedEventArgs(float temperature, float windSpeed, float windDirection) : base(WeatherEventType.WeatherChanged)
        {
            Temperature = temperature;
            WindSpeed = windSpeed;
            WindDirection = windDirection;
        }
    }

    public class WeatherForecastUpdatedEventArgs : WeatherEventArgs
    {
        public string Forecast { get; private set; }
        public WeatherForecastUpdatedEventArgs(string forecast) : base(WeatherEventType.WeatherForecastUpdated)
        {
            Forecast = forecast;
        }
    }
}

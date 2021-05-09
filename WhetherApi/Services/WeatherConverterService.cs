using System.Collections.Generic;
using WhetherApi.Contracts;
using WhetherApi.Enums;

namespace WhetherApi.Services
{
    public class WeatherConverterService : IWeatherConverterService
    {
        public WeatherForecast Convert(TemperatureType type, double value) {
            var weatherForecast = new WeatherForecast();
            switch (type)
            {
                case TemperatureType.Celsius:
                    weatherForecast.Celsius = value;
                    weatherForecast.Kelvin = 273 + value;
                    weatherForecast.Fahrenheit = value * 18 / 10 + 32;
                    break;
                case TemperatureType.Kelvin:
                    weatherForecast.Kelvin = value;
                    weatherForecast.Celsius = value - 273;
                    weatherForecast.Fahrenheit = (value - 273) * 18 / 10 + 32;
                    break;
                case TemperatureType.Fahrenheit:
                    weatherForecast.Fahrenheit = value;
                    weatherForecast.Celsius = 5 * (value - 32) / 9;
                    weatherForecast.Kelvin = 5 * (value - 32) / 9 + 273;
                    break;
                default:
                    break;
            }
            return weatherForecast;
        }
    }
}

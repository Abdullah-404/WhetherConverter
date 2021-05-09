using System.Collections.Generic;

namespace WhetherApi.Contracts
{
    public interface IWeatherConverterService
    {
        WeatherForecast Convert(TemperatureType type, double value);
    }
}
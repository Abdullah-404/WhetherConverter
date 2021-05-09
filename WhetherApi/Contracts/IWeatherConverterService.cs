using System.Collections.Generic;
using WhetherApi.Enums;

namespace WhetherApi.Contracts
{
    public interface IWeatherConverterService
    {
        WeatherForecast Convert(TemperatureType type, double value);
    }
}
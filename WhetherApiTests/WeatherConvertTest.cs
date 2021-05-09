using System;
using Xunit;
using WhetherApi.Controllers;
using WhetherApi.Contracts;
using WhetherApi.Enums;
using WhetherApi;
using Moq;

namespace WhetherApiTests
{
    public class WeatherConvertTest
    {
        private readonly Mock<IWeatherConverterService> _service;
        public WeatherConvertTest()
        {
            _service = new Mock<IWeatherConverterService>();
        }

        [Fact]
        public void Convert_Celsius_ToKelvinFahrenheit()
        {
            double celsius = 10;
            double kelvin = 283;
           // double fahrenheit = 50;
            var controller = new WeatherForecastController(_service.Object);

            var result = controller.Get(TemperatureType.Celsius, celsius) as WeatherForecast;

            Assert.True(result.Kelvin == kelvin);
        }
    }
}

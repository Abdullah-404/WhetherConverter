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
            double fahrenheit = 50;
           _service.Setup(s => s.Convert(TemperatureType.Celsius, celsius))
            .Returns(this.result);
            var controller = new WeatherForecastController(_service.Object);

            var result = controller.Get(TemperatureType.Celsius, celsius) as WeatherForecast;

            Assert.True(result.Kelvin == kelvin);
            Assert.True(result.Fahrenheit == fahrenheit);
        }

        [Fact]
        public void Convert_Kelvin_ToFahrenheitCelsius()
        {
            double celsius = 10;
            double kelvin = 283;
            double fahrenheit = 50;
           _service.Setup(s => s.Convert(TemperatureType.Kelvin, kelvin))
            .Returns(this.result);
            var controller = new WeatherForecastController(_service.Object);

            var result = controller.Get(TemperatureType.Kelvin, kelvin) as WeatherForecast;

            Assert.True(result.Fahrenheit == fahrenheit);
            Assert.True(result.Celsius == celsius);
        }

        [Fact]
        public void Convert_Fahrenheit_ToCelsiusKelvin()
        {
            double celsius = 10;
            double kelvin = 283;
            double fahrenheit = 50;
           _service.Setup(s => s.Convert(TemperatureType.Fahrenheit, fahrenheit))
            .Returns(this.result);
            var controller = new WeatherForecastController(_service.Object);

            var result = controller.Get(TemperatureType.Fahrenheit, fahrenheit) as WeatherForecast;

            Assert.True(result.Celsius == celsius);
            Assert.True(result.Kelvin == kelvin);
        }

        private readonly WeatherForecast result = new WeatherForecast {
            Celsius = 10,
            Kelvin = 283,
            Fahrenheit = 50
        };
    }
}

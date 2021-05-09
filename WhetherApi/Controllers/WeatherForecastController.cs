using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhetherApi.Contracts;

namespace WhetherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherConverterService _service;
        public WeatherForecastController(IWeatherConverterService service)
        {
            _service = service;
        }

        [HttpGet]
        public WeatherForecast Get(TemperatureType type, double value)
        {
            return _service.Convert(type, value);
        }
    }
}

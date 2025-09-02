using AutoMapper;
using BetterWeatherApi.Domain.Models.Forecast.Responses;
using BetterWeatherApi.Logic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterWeatherApi.Web.Controllers
{
    [Route("api/current")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;

        public CurrentWeatherController(IWeatherService weatherService, IMapper mapper)
        {
            _weatherService = weatherService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentWeather(string location, int hour)
        {
            var weatherData = await _weatherService.GetCurrentWeather(location, hour);

            if (weatherData != null)
            {
                var response = _mapper.Map<HourlyForecastResponseModel>(weatherData);

                var host = $"{Request.Scheme}://{Request.Host}";
                response = _weatherService.InsertAdditionalWeatherData(response, host);
                return Ok(response);
            }

            return NotFound();
        }
    }
}

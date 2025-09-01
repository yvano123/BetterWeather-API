using AutoMapper;
using BetterWeatherApi.Domain.Models.Forecast.Responses;
using BetterWeatherApi.Logic.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BetterWeatherApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;

        public ForecastController(IWeatherService weatherService, IMapper mapper) 
        {
            _weatherService = weatherService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string location)
        {
            var weatherData = await _weatherService.GetWeekForecast(location);
            if (weatherData != null)
            {
                var response = _mapper.Map<List<DailyForecastResponseModel>>(weatherData);

                var host = $"{Request.Scheme}://{Request.Host}";
                response = _weatherService.InsertAdditionalWeatherData(response, host);
                return Ok(response);
            }

            return NotFound();

        }
    }
}

using BetterWeatherApi.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetterWeatherApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public ForecastController(IWeatherService weatherService) 
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string location)
        {
            var data = await _weatherService.GetWeekForecast(location);

            return Ok(data);
        }
    }
}

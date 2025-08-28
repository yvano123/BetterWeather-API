using BetterWeatherApi.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterWeatherApi.Web.Controllers
{
    [Route("api/current")]
    [ApiController]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public CurrentWeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrentWeather(string location)
        {
            _weatherService.
        }
    }
}

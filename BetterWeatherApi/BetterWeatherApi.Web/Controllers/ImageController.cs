using BetterWeatherApi.Domain.Models.Image;
using BetterWeatherApi.Logic.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterWeatherApi.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    ICityImageClient _client;
    public ImageController(ICityImageClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string location)
    {
        string url = await _client.GetCityImage(location);

        ImageResponseModel response = new(url);
        return Ok(response);
    }
}

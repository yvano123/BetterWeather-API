using BetterWeatherApi.Domain.Models.Image;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Logic.Clients;

public interface ICityImageClient
{
    public Task<string?> GetCityImage(string location);
}
public class CityImageClient:ICityImageClient
{
    private readonly HttpClient _client;
    private readonly string _apiKey;
    public CityImageClient(string apiKey, HttpClient client)
    {
        _client = client;
        _apiKey = apiKey;
        _client.BaseAddress = new Uri("https://serpapi.com/");
    }

    public async Task<string?> GetCityImage(string location)
    {
        var response = await _client.GetAsync($"search.json?engine=google_maps&q={location.ToLower()}&api_key={_apiKey}");


        var json = await response.Content.ReadAsStringAsync();
        var model = await response.Content.ReadFromJsonAsync<GoogleImageResponseModel>();

        return model?.place_results.images.FirstOrDefault()?.thumbnail;
    }
}

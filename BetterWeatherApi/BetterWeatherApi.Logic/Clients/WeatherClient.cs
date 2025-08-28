using BetterWeatherApi.Domain.Models.Forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BetterWeatherApi.Logic.Clients;

public interface IWeatherClient 
{
    public Task<ForecastResponseModel> GetForecast(string location);
}

public class WeatherClient:IWeatherClient
{
    private readonly HttpClient _client;
    private readonly string _apiKey;

    public WeatherClient(string apiKey, HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://api.tomorrow.io/v4/");
        _apiKey = apiKey;
    }

    public async Task<ForecastResponseModel> GetForecast(string location)
    {
        var response  = await _client.GetAsync($"weather/forecast?location={location.Replace(" ", "%20")}&apikey={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var json = await response.Content.ReadAsStringAsync();
        var models = await response.Content.ReadFromJsonAsync<ForecastResponseModel>();

        return models;
    }
}

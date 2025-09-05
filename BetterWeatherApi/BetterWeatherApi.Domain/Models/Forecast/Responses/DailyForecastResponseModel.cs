using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Forecast.Responses;

public class DailyForecastResponseModel
{
    public float TemperatureMax { get; set; }
    public float TemperatureMin { get; set; }
    [JsonPropertyName("Humidity")]
    public int HumidityAvg { get; set; }
    [JsonPropertyName("WindDirection")]
    public int WindDirectionAvg { get; set; }
    [JsonPropertyName("WindSpeed")]

    public float WindSpeedAvg { get; set; }
    [JsonPropertyName("UvIndex")]

    public int UvIndexMax { get; set; }

    [JsonPropertyName("Pressure")]
    public float PressureSurfaceLevelAvg { get; set; }
    [JsonPropertyName("WeatherCode")]
    public int WeatherCodeMax { get; set; }
    public string WeatherMessage { get; set; }
    public string WeatherIconUrlNight { get; set; }
    public string WeatherIconUrlDay { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public DateTime Time { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Forecast.Responses;

public class HourlyForecastResponseModel
{
    public float Temperature { get; set; }
    public float TemperatureApparent { get; set; }
    public int Humidity { get; set; }
    public int UvIndex { get; set; }
    public int WindDirection { get; set; }
    [JsonPropertyName("Pressure")]
    public float PressureSurfaceLevel { get; set; }
    public int WeatherCode { get; set; }
    public string WeatherMessage { get; set; }
    public string WeatherIconUrl { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public DateTime Time { get; set; }
    public bool Daytime { get; set; }
    public string Location { get; set; }

}

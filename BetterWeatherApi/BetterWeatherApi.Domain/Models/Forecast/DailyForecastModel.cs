using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Forecast;

public class DailyForecastModel
{
    public float TemperatureMax { get; set; }
    public float TemperatureMin { get; set; }
    public int HumidityAvg { get; set; }
    public int WindDirectionAvg { get; set; }
    public float WindSpeedAvg { get; set; }
    public int UvIndexMax;
    public float PressureSurfaceLevelAvg { get; set; }
    public int WeatherCodeMax { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public DateTime Time { get; set; }
}

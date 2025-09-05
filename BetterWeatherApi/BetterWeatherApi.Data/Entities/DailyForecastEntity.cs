using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Data.Entities;

public class DailyForecastEntity:BaseEntity
{
    public float TemperatureMax { get; set; }
    public float TemperatureMin { get; set; }
    public int HumidityAvg { get; set; }
    public int WindDirectionAvg { get; set; }
    public float WindSpeedAvg { get; set; }
    public int UvIndexMax { get; set; }
    public float PressureSurfaceLevelAvg { get; set; }
    public int WeatherCodeMax { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public DateTime LastRequest { get; set; } = DateTime.Now;
}

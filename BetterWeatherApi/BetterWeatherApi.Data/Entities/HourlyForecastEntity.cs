using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Data.Entities;

public class HourlyForecastEntity:BaseEntity
{
    public float Temperature { get; set; }
    public float TemperatureApparent { get; set; }
    public int Humidity { get; set; }
    public int UvIndex { get; set; }
    public int WindDirection { get; set; }
    public float PressureSurfaceLevel { get; set; }
    public int WeatherCode { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public DateTime LastRequest { get; set; } = DateTime.Now;

}

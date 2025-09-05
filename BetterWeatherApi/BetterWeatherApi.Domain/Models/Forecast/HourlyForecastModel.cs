using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Forecast;

public class HourlyForecastModel
{
    public float Temperature { get; set; }
    public float TemperatureApparent { get; set; }
    public int Humidity { get; set; }
    public int UvIndex { get; set; }
    public int WindDirection { get; set; }
    public float WindSpeed { get; set; }
    public float PressureSurfaceLevel { get; set; }
    public int WeatherCode { get; set; }
    public DateTime Time { get; set; }
}

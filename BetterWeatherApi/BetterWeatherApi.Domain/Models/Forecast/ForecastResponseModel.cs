using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Forecast;


public class ForecastResponseModel
{
    public Timelines Timelines { get; set; }
    public Location Location { get; set; }
}

public class Timelines
{
    public Minutely[] Minutely { get; set; }
    public Hourly[] Hourly { get; set; }
    public Daily[] Daily { get; set; }
}

public class Minutely
{
    public DateTime Time { get; set; }
    public MinutelyValues Values { get; set; }
}

public class MinutelyValues
{
    public float? AltimeterSetting { get; set; }
    public float? CloudBase { get; set; }
    public float? CloudCeiling { get; set; }
    public float? CloudCover { get; set; }
    public float? DewPoint { get; set; }
    public float? FreezingRainIntensity { get; set; }
    public float? Humidity { get; set; }
    public float? PrecipitationProbability { get; set; }
    public float? PressureSeaLevel { get; set; }
    public float? PressureSurfaceLevel { get; set; }
    public float? RainIntensity { get; set; }
    public float? SleetIntensity { get; set; }
    public float? SnowIntensity { get; set; }
    public float? Temperature { get; set; }
    public float? TemperatureApparent { get; set; }
    public float? UvHealthConcern { get; set; }
    public float? UvIndex { get; set; }
    public float? Visibility { get; set; }
    public float? WeatherCode { get; set; }
    public float? WindDirection { get; set; }
    public float? WindGust { get; set; }
    public float? WindSpeed { get; set; }
}

public class Hourly
{
    public DateTime Time { get; set; }
    public HourlyValues Values { get; set; }
}

public class HourlyValues
{
    public float? AltimeterSetting { get; set; }
    public float? CloudBase { get; set; }
    public float? CloudCeiling { get; set; }
    public float? CloudCover { get; set; }
    public float? DewPoint { get; set; }
    public float? Evapotranspiration { get; set; }
    public float? FreezingRainIntensity { get; set; }
    public float? Humidity { get; set; }
    public float? IceAccumulation { get; set; }
    public float? IceAccumulationLwe { get; set; }
    public float? PrecipitationProbability { get; set; }
    public float? PressureSeaLevel { get; set; }
    public float? PressureSurfaceLevel { get; set; }
    public float? RainAccumulation { get; set; }
    public float? RainIntensity { get; set; }
    public float? SleetAccumulation { get; set; }
    public float? SleetAccumulationLwe { get; set; }
    public float? SleetIntensity { get; set; }
    public float? SnowAccumulation { get; set; }
    public float? SnowAccumulationLwe { get; set; }
    public float? SnowDepth { get; set; }
    public float? SnowIntensity { get; set; }
    public float? Temperature { get; set; }
    public float? TemperatureApparent { get; set; }
    public float? UvHealthConcern { get; set; }
    public float? UvIndex { get; set; }
    public float? Visibility { get; set; }
    public float? WeatherCode { get; set; }
    public float? WindDirection { get; set; }
    public float? WindGust { get; set; }
    public float? WindSpeed { get; set; }
}

public class Daily
{
    public DateTime Time { get; set; }
    public DailyValues Values { get; set; }
}

public class DailyValues
{
    public float? AltimeterSettingAvg { get; set; }
    public float? AltimeterSettingMax { get; set; }
    public float? AltimeterSettingMin { get; set; }
    public float? CloudBaseAvg { get; set; }
    public float? CloudBaseMax { get; set; }
    public float? CloudBaseMin { get; set; }
    public float? CloudCeilingAvg { get; set; }
    public float? CloudCeilingMax { get; set; }
    public float? CloudCeilingMin { get; set; }
    public float? CloudCoverAvg { get; set; }
    public float? CloudCoverMax { get; set; }
    public float? CloudCoverMin { get; set; }
    public float? DewPointAvg { get; set; }
    public float? DewPointMax { get; set; }
    public float? DewPointMin { get; set; }
    public float? EvapotranspirationAvg { get; set; }
    public float? EvapotranspirationMax { get; set; }
    public float? EvapotranspirationMin { get; set; }
    public float? EvapotranspirationSum { get; set; }
    public float? FreezingRainIntensityAvg { get; set; }
    public float? FreezingRainIntensityMax { get; set; }
    public float? FreezingRainIntensityMin { get; set; }
    public float? HumidityAvg { get; set; }
    public float? HumidityMax { get; set; }
    public float? HumidityMin { get; set; }
    public float? IceAccumulationAvg { get; set; }
    public float? IceAccumulationLweAvg { get; set; }
    public float? IceAccumulationLweMax { get; set; }
    public float? IceAccumulationLweMin { get; set; }
    public float? IceAccumulationLweSum { get; set; }
    public float? IceAccumulationMax { get; set; }
    public float? IceAccumulationMin { get; set; }
    public float? IceAccumulationSum { get; set; }
    public DateTime? MoonriseTime { get; set; }
    public DateTime? MoonsetTime { get; set; }
    public float? PrecipitationProbabilityAvg { get; set; }
    public float? PrecipitationProbabilityMax { get; set; }
    public float? PrecipitationProbabilityMin { get; set; }
    public float? PressureSeaLevelAvg { get; set; }
    public float? PressureSeaLevelMax { get; set; }
    public float? PressureSeaLevelMin { get; set; }
    public float? PressureSurfaceLevelAvg { get; set; }
    public float? PressureSurfaceLevelMax { get; set; }
    public float? PressureSurfaceLevelMin { get; set; }
    public float? RainAccumulationAvg { get; set; }
    public float? RainAccumulationMax { get; set; }
    public float? RainAccumulationMin { get; set; }
    public float? RainAccumulationSum { get; set; }
    public float? RainIntensityAvg { get; set; }
    public float? RainIntensityMax { get; set; }
    public float? RainIntensityMin { get; set; }
    public float? SleetAccumulationAvg { get; set; }
    public float? SleetAccumulationLweAvg { get; set; }
    public float? SleetAccumulationLweMax { get; set; }
    public float? SleetAccumulationLweMin { get; set; }
    public float? SleetAccumulationLweSum { get; set; }
    public float? SleetAccumulationMax { get; set; }
    public float? SleetAccumulationMin { get; set; }
    public float? SleetIntensityAvg { get; set; }
    public float? SleetIntensityMax { get; set; }
    public float? SleetIntensityMin { get; set; }
    public float? SnowAccumulationAvg { get; set; }
    public float? SnowAccumulationLweAvg { get; set; }
    public float? SnowAccumulationLweMax { get; set; }
    public float? SnowAccumulationLweMin { get; set; }
    public float? SnowAccumulationLweSum { get; set; }
    public float? SnowAccumulationMax { get; set; }
    public float? SnowAccumulationMin { get; set; }
    public float? SnowAccumulationSum { get; set; }
    public float? SnowDepthAvg { get; set; }
    public float? SnowDepthMax { get; set; }
    public float? SnowDepthMin { get; set; }
    public float? SnowDepthSum { get; set; }
    public float? SnowIntensityAvg { get; set; }
    public float? SnowIntensityMax { get; set; }
    public float? SnowIntensityMin { get; set; }
    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public float? TemperatureApparentAvg { get; set; }
    public float? TemperatureApparentMax { get; set; }
    public float? TemperatureApparentMin { get; set; }
    public float? TemperatureAvg { get; set; }
    public float? TemperatureMax { get; set; }
    public float? TemperatureMin { get; set; }
    public float? UvHealthConcernAvg { get; set; }
    public float? UvHealthConcernMax { get; set; }
    public float? UvHealthConcernMin { get; set; }
    public float? UvIndexAvg { get; set; }
    public float? UvIndexMax { get; set; }
    public float? UvIndexMin { get; set; }
    public float? VisibilityAvg { get; set; }
    public float? VisibilityMax { get; set; }
    public float? VisibilityMin { get; set; }
    public float? WeatherCodeMax { get; set; }
    public float? WeatherCodeMin { get; set; }
    public float? WindDirectionAvg { get; set; }
    public float? WindGustAvg { get; set; }
    public float? WindGustMax { get; set; }
    public float? WindGustMin { get; set; }
    public float? WindSpeedAvg { get; set; }
    public float? WindSpeedMax { get; set; }
    public float? WindSpeedMin { get; set; }
}

public class Location
{
    public float? Lat { get; set; }
    public float? Lon { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
}

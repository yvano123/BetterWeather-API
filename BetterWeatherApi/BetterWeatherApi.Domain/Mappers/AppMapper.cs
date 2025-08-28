using AutoMapper;
using BetterWeatherApi.Data.Entities;
using BetterWeatherApi.Domain.Models.Forecast;

namespace BetterWeatherApi.Domain.Mappers;

public class AppMapper : Profile
{
    public AppMapper()
    {
        CreateMap<DailyForecastEntity, DailyForecastModel>();
        CreateMap<DailyForecastModel, DailyForecastEntity>();

        CreateMap<HourlyForecastModel, HourlyForecastEntity>();
        CreateMap<HourlyForecastEntity, HourlyForecastModel>();

        CreateMap<DailyValues, DailyForecastModel>();
        CreateMap<HourlyValues, HourlyForecastModel>();
    }
}

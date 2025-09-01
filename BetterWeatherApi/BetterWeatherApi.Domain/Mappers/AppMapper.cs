using AutoMapper;
using BetterWeatherApi.Data.Entities;
using BetterWeatherApi.Domain.Models.Forecast;
using BetterWeatherApi.Domain.Models.Forecast.Responses;

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

        CreateMap<HourlyForecastModel, HourlyForecastResponseModel>();
        CreateMap<DailyForecastModel, DailyForecastResponseModel>();
    }
}

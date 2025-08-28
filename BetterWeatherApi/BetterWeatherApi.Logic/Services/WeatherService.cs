using BetterWeatherApi.Logic.Clients;
using BetterWeatherApi.Domain.Models.Forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterWeatherApi.Data;
using BetterWeatherApi.Domain.Mappers;
using AutoMapper;
using BetterWeatherApi.Data.Entities;

namespace BetterWeatherApi.Logic.Services;

public interface IWeatherService
{
    public Task<List<DailyForecastModel>> GetWeekForecast(string location);
    public Task<HourlyForecastModel> GetCurrentWeather(string location);
}

public class WeatherService : IWeatherService
{
    private readonly IWeatherClient _client;
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public WeatherService(IWeatherClient client, DatabaseContext context, IMapper mapper)
    {
        _client = client;
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DailyForecastModel>> GetWeekForecast(string location)
    {
        ForecastResponseModel forecast;
        List<DailyForecastEntity> days;

        if (_context.DailyForecasts.Count(x => x.Location == location) >= 5)
        {
            if (_context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.LastRequest).FirstOrDefault().LastRequest.AddMinutes(30) > DateTime.Now)
            {
                days = _context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.Time).Skip(1).Take(5).ToList();
                return _mapper.Map<List<DailyForecastModel>>(days);
            }
        }
        forecast = await _client.GetForecast(location);
        await AddForecastToDatabase(location, forecast);

        days = _context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.Time).Skip(1).Take(5).ToList();

        return _mapper.Map<List<DailyForecastModel>>(days);
    }

    public async Task<HourlyForecastModel> GetCurrentWeather(string location)
    {
        ForecastResponseModel forecast;
        HourlyForecastEntity hour;

        if (_context.HourlyForecasts.Any(x => x.Location == location))
        {
            if(_context.HourlyForecasts.OrderByDescending(x => x.Time).First(x => x.Location == location).LastRequest.AddMinutes(30) > DateTime.Now)
            {
                hour = _context.HourlyForecasts.OrderByDescending(x => x.Time).First(x => x.Location == location);
                return _mapper.Map<HourlyForecastModel>(hour);
            }
        }
        forecast = await _client.GetForecast(location);
        await AddForecastToDatabase(location, forecast);

        hour = _context.HourlyForecasts.OrderByDescending(x => x.Time).First(x => x.Location == location);
        return _mapper.Map<HourlyForecastModel>(hour);
    }

    private async Task AddForecastToDatabase(string location, ForecastResponseModel forecast)
    {
        foreach (var hourly in forecast.Timelines.Hourly)
        {
            var model = _mapper.Map<HourlyForecastModel>(hourly.Values);
            model.Time = hourly.Time;

            var entity = _mapper.Map<HourlyForecastEntity>(model);
            entity.Location = location;

            _context.HourlyForecasts.Add(entity);
            await _context.SaveChangesAsync();
        }

        foreach (var daily in forecast.Timelines.Daily)
        {
            var model = _mapper.Map<DailyForecastModel>(daily.Values);
            model.Time = daily.Time;

            var entity = _mapper.Map<DailyForecastEntity>(model);
            entity.Location = location;

            _context.DailyForecasts.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public HourlyForecastModel GetLatestWeather(string location)
    {
        return default;
    }
}

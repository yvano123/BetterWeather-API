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
using BetterWeatherApi.Domain.Models.Forecast.Responses;
using System.Runtime.CompilerServices;

namespace BetterWeatherApi.Logic.Services;

public interface IWeatherService
{
    public Task<List<DailyForecastModel>> GetWeekForecast(string location);
    public Task<HourlyForecastModel> GetCurrentWeather(string location);
    public HourlyForecastResponseModel InsertAdditionalWeatherData(HourlyForecastResponseModel model, string host);
    public List<DailyForecastResponseModel> InsertAdditionalWeatherData(List<DailyForecastResponseModel> models, string host);
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
        TomorrowResponseModel forecast;
        List<DailyForecastEntity> days;

        if (_context.DailyForecasts.Count(x => x.Location == location) >= 5)
        {
            if (_context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.LastRequest).FirstOrDefault()?.LastRequest.AddMinutes(30) > DateTime.Now)
            {
                days = _context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.Time).Skip(1).Take(5).ToList();
                return _mapper.Map<List<DailyForecastModel>>(days);
            }
        }
        forecast = await _client.GetForecast(location);
        if (!await AddForecastToDatabase(location, forecast))
        {
            return default;
        }

        days = _context.DailyForecasts.Where(x => x.Location == location).OrderByDescending(x => x.Time).Skip(1).Take(5).ToList();

        return _mapper.Map<List<DailyForecastModel>>(days);
    }

    public async Task<HourlyForecastModel> GetCurrentWeather(string location)
    {
        TomorrowResponseModel forecast;
        HourlyForecastEntity hour;

        if (_context.HourlyForecasts.Any(x => x.Location == location))
        {
            if(_context.HourlyForecasts.OrderByDescending(x => x.Time).FirstOrDefault(x => x.Location == location)?.LastRequest.AddMinutes(30) > DateTime.Now)
            {
                hour = _context.HourlyForecasts.OrderByDescending(x => x.Time).First(x => x.Location == location);
                return _mapper.Map<HourlyForecastModel>(hour);
            }
        }
        forecast = await _client.GetForecast(location);
        if(!await AddForecastToDatabase(location, forecast))
        {
            return default;
        }

        hour = _context.HourlyForecasts.OrderByDescending(x => x.Time).First(x => x.Location == location);
        return _mapper.Map<HourlyForecastModel>(hour);
    }

    private async Task<bool> AddForecastToDatabase(string location, TomorrowResponseModel forecast)
    {
        if (forecast == null) return false;
        foreach (var hourly in forecast.Timelines.Hourly)
        {
            var model = _mapper.Map<HourlyForecastModel>(hourly.Values);
            model.Time = hourly.Time;

            var entity = _mapper.Map<HourlyForecastEntity>(model);
            entity.Location = location;

            _context.HourlyForecasts.Add(entity);

        }

        foreach (var daily in forecast.Timelines.Daily)
        {
            var model = _mapper.Map<DailyForecastModel>(daily.Values);
            model.Time = daily.Time;

            var entity = _mapper.Map<DailyForecastEntity>(model);
            entity.Location = location;

            _context.DailyForecasts.Add(entity);
        }
            await _context.SaveChangesAsync();
        return true;
    }

    public HourlyForecastModel GetLatestWeather(string location)
    {
        return default;
    }

    public HourlyForecastResponseModel InsertAdditionalWeatherData(HourlyForecastResponseModel model, string host)
    {
        model.WeatherMessage = WeatherCodes.All.FirstOrDefault(x => x.Code == model.WeatherCode)?.Description ?? "Unknown weather";

        string dayPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WeatherIcons", model.WeatherCode.ToString()+"0.png");
        string nightPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WeatherIcons", model.WeatherCode.ToString() + "1.png");

        bool dayExists = false;

        if (File.Exists(dayPath)) 
        {
            model.WeatherIconUrlDay = host+$"/WeatherIcons/{model.WeatherCode.ToString()}0.png";
            dayExists = true;
        }

        if (File.Exists(nightPath))
        {
            model.WeatherIconUrlNight = host + $"/WeatherIcons/{model.WeatherCode.ToString()}1.png";
        }
        else if (dayExists)
        {
            model.WeatherIconUrlNight = host + $"/WeatherIcons/{model.WeatherCode.ToString()}0.png";
        }

        return model;
    }

    public List<DailyForecastResponseModel> InsertAdditionalWeatherData(List<DailyForecastResponseModel> models, string host)
    {
        List<DailyForecastResponseModel> newModels = new();

        foreach(var model in models)
        {
            newModels.Add(InsertAdditionalWeatherData(model, host));
        }

        return newModels;
    }

    public DailyForecastResponseModel InsertAdditionalWeatherData(DailyForecastResponseModel model, string host)
    {
        model.WeatherMessage = WeatherCodes.All.FirstOrDefault(x => x.Code == model.WeatherCodeMax)?.Description ?? "Unknown weather";

        string dayPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WeatherIcons", model.WeatherCodeMax.ToString() + "0.png");
        string nightPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WeatherIcons", model.WeatherCodeMax.ToString() + "1.png");

        bool dayExists = false;

        if (File.Exists(dayPath))
        {
            model.WeatherIconUrlDay = host + $"/WeatherIcons/{model.WeatherCodeMax.ToString()}0.png";
            dayExists = true;
        }

        if (File.Exists(nightPath))
        {
            model.WeatherIconUrlNight = host + $"/WeatherIcons/{model.WeatherCodeMax.ToString()}1.png";
        }
        else if (dayExists)
        {
            model.WeatherIconUrlNight = host + $"/WeatherIcons/{model.WeatherCodeMax.ToString()}0.png";
        }

        return model;
    }
}

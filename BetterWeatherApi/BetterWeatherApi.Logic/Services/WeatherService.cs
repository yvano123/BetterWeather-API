using BetterWeatherApi.Logic.Clients;
using BetterWeatherApi.Domain.Models.Forecast;
using BetterWeatherApi.Data;
using AutoMapper;
using BetterWeatherApi.Data.Entities;
using BetterWeatherApi.Domain.Models.Forecast.Responses;

namespace BetterWeatherApi.Logic.Services;

public interface IWeatherService
{
    public Task<List<DailyForecastModel>> GetWeekForecast(string location);
    public Task<HourlyForecastModel> GetCurrentWeather(string location, int time);
    public Task<List<HourlyForecastModel>> GetHourlyForecast(string location, int time);
    public HourlyForecastResponseModel InsertAdditionalWeatherData(HourlyForecastResponseModel model, string host);
    public List<HourlyForecastResponseModel> InsertAdditionalWeatherData(List<HourlyForecastResponseModel> model, string host);
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
                days = _context.DailyForecasts.Where(x => x.Location == location).OrderBy(x => x.Time).Skip(1).Take(5).ToList();
                return _mapper.Map<List<DailyForecastModel>>(days);
            }
        }
        forecast = await _client.GetForecast(location);
        if (!await AddForecastToDatabase(location, forecast))
        {
            return default;
        }

        days = _context.DailyForecasts.Where(x => x.Location == location).OrderBy(x => x.Time).Skip(1).Take(5).ToList();

        return _mapper.Map<List<DailyForecastModel>>(days);
    }

    public async Task<List<HourlyForecastModel>> GetHourlyForecast(string location, int time)
    {
        TomorrowResponseModel forecast;
        List<HourlyForecastEntity> days;

        if (_context.HourlyForecasts.Count(x => x.Location == location) >= 5)
        {
            if (_context.HourlyForecasts.Where(x => x.Location == location && x.Time.Hour >= time && x.Time.Date >= DateTime.Now.Date).OrderByDescending(x => x.LastRequest).FirstOrDefault()?.LastRequest.AddMinutes(30) > DateTime.Now)
            {
                days = _context.HourlyForecasts.Where(x => x.Location == location && x.Time.Hour >= time && x.Time.Date >= DateTime.Now.Date).OrderBy(x => x.Time).Skip(1).Take(5).ToList();
                return _mapper.Map<List<HourlyForecastModel>>(days);
            }
        }
        forecast = await _client.GetForecast(location);
        if (!await AddForecastToDatabase(location, forecast))
        {
            return default;
        }

        days = _context.HourlyForecasts.Where(x => x.Location == location && x.Time.Hour >= time && x.Time.Date >= DateTime.Now.Date).OrderBy(x => x.Time).Skip(1).Take(5).ToList();

        return _mapper.Map<List<HourlyForecastModel>>(days);
    }

    public async Task<HourlyForecastModel> GetCurrentWeather(string location, int time)
    {
        TomorrowResponseModel forecast;
        HourlyForecastEntity hour;

        if (_context.HourlyForecasts.Any(x => x.Location == location))
        {
            if(_context.HourlyForecasts.OrderByDescending(x => x.Time).FirstOrDefault(x => x.Location == location && x.Time.Hour <= time && x.Time.Date == DateTime.Now.Date)?.LastRequest.AddMinutes(30) > DateTime.Now)
            {
                hour = _context.HourlyForecasts.OrderBy(x => x.Time).First(x => x.Location == location && x.Time.Hour <= time && x.Time.Date == DateTime.Now.Date);
                return _mapper.Map<HourlyForecastModel>(hour);
            }
        }
        forecast = await _client.GetForecast(location);
        if(!await AddForecastToDatabase(location, forecast))
        {
            return default;
        }

        hour = _context.HourlyForecasts.OrderBy(x => x.Time).First(x => x.Location == location && x.Time.Hour <= time && x.Time.Date == DateTime.Now.Date);
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
            if(_context.HourlyForecasts.Any(x => x.Time == hourly.Time && x.Location == location))
            {
                var ent = _context.HourlyForecasts.First(x => x.Time == hourly.Time && x.Location == location);
                _context.HourlyForecasts.Remove(ent);
            }
            _context.HourlyForecasts.Add(entity);

        }

        foreach (var daily in forecast.Timelines.Daily)
        {
            var model = _mapper.Map<DailyForecastModel>(daily.Values);
            model.Time = daily.Time;

            var entity = _mapper.Map<DailyForecastEntity>(model);
            entity.Location = location;

            if (_context.DailyForecasts.Any(x => x.Time.Date == daily.Time.Date && x.Location == location))
            {
                var ent = _context.DailyForecasts.First(x => x.Time.Date == daily.Time.Date && x.Location == location);
                _context.DailyForecasts.Remove(ent);
            }

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
        int timeOfDay = model.Time.Hour > 19 || model.Time.Hour < 6? 1 : 0;

        model.Daytime = timeOfDay == 0? true:false;

        string iconPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "WeatherIcons", model.WeatherCode.ToString() + timeOfDay + ".png");

        if (File.Exists(iconPath)) 
        {
            model.WeatherIconUrl = host+$"/WeatherIcons/{model.WeatherCode.ToString()}{timeOfDay}.png";
        }
        else
        {
            model.WeatherIconUrl = host + $"/WeatherIcons/{model.WeatherCode.ToString()}0.png";
        }

        var daily = _context.DailyForecasts.FirstOrDefault(x => x.Location == model.Location && x.Time.Date == model.Time.Date);

        model.SunriseTime = daily.SunriseTime;
        model.SunsetTime = daily.SunsetTime;


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

    public List<HourlyForecastResponseModel> InsertAdditionalWeatherData(List<HourlyForecastResponseModel> models, string host)
    {
        List<HourlyForecastResponseModel> newModels = new();

        foreach (var model in models)
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

using BetterWeatherApi.Logic.Clients;
using BetterWeatherApi.Logic.Services;
using BetterWeatherApi.Data;
using Microsoft.EntityFrameworkCore;
using BetterWeatherApi.Domain.Mappers;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddScoped<IWeatherClient>(prov =>
    {
        HttpClient client = new();
        return new WeatherClient(builder.Configuration.GetValue<string>("apiKey") ?? "", client);
    });
    builder.Services.AddScoped<IWeatherService, WeatherService>();
    builder.Services.AddAutoMapper(typeof(AppMapper));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

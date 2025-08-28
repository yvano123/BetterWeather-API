using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterWeatherApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterWeatherApi.Data;

public class DatabaseContext : DbContext
{
    public DbSet<HourlyForecastEntity> HourlyForecasts => Set<HourlyForecastEntity>();
    public DbSet<DailyForecastEntity> DailyForecasts => Set<DailyForecastEntity>();

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyForecastEntity>();
        modelBuilder.Entity<HourlyForecastEntity>();
    }
}

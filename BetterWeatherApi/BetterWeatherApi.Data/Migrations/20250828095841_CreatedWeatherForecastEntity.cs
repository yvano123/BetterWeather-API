using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterWeatherApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedWeatherForecastEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    FeelTemperature = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    UvIndex = table.Column<int>(type: "int", nullable: false),
                    WindDirection = table.Column<int>(type: "int", nullable: false),
                    PressureSurfaceLevel = table.Column<float>(type: "real", nullable: false),
                    WeatherCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}

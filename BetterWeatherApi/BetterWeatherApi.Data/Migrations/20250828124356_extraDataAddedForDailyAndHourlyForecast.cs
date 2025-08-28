using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterWeatherApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class extraDataAddedForDailyAndHourlyForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "DailyForecasts");

            migrationBuilder.RenameColumn(
                name: "FeelTemperature",
                table: "HourlyForecasts",
                newName: "TemperatureApparent");

            migrationBuilder.RenameColumn(
                name: "WindDirection",
                table: "DailyForecasts",
                newName: "WindDirectionAvg");

            migrationBuilder.RenameColumn(
                name: "WeatherCode",
                table: "DailyForecasts",
                newName: "WeatherCodeMax");

            migrationBuilder.RenameColumn(
                name: "UvIndex",
                table: "DailyForecasts",
                newName: "HumidityAvg");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "DailyForecasts",
                newName: "TemperatureMin");

            migrationBuilder.RenameColumn(
                name: "PressureSurfaceLevel",
                table: "DailyForecasts",
                newName: "TemperatureMax");

            migrationBuilder.RenameColumn(
                name: "FeelTemperature",
                table: "DailyForecasts",
                newName: "PressureSurfaceLevelAvg");

            migrationBuilder.AddColumn<DateTime>(
                name: "SunriseTime",
                table: "HourlyForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SunsetTime",
                table: "HourlyForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SunriseTime",
                table: "DailyForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SunsetTime",
                table: "DailyForecasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SunriseTime",
                table: "HourlyForecasts");

            migrationBuilder.DropColumn(
                name: "SunsetTime",
                table: "HourlyForecasts");

            migrationBuilder.DropColumn(
                name: "SunriseTime",
                table: "DailyForecasts");

            migrationBuilder.DropColumn(
                name: "SunsetTime",
                table: "DailyForecasts");

            migrationBuilder.RenameColumn(
                name: "TemperatureApparent",
                table: "HourlyForecasts",
                newName: "FeelTemperature");

            migrationBuilder.RenameColumn(
                name: "WindDirectionAvg",
                table: "DailyForecasts",
                newName: "WindDirection");

            migrationBuilder.RenameColumn(
                name: "WeatherCodeMax",
                table: "DailyForecasts",
                newName: "WeatherCode");

            migrationBuilder.RenameColumn(
                name: "TemperatureMin",
                table: "DailyForecasts",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "TemperatureMax",
                table: "DailyForecasts",
                newName: "PressureSurfaceLevel");

            migrationBuilder.RenameColumn(
                name: "PressureSurfaceLevelAvg",
                table: "DailyForecasts",
                newName: "FeelTemperature");

            migrationBuilder.RenameColumn(
                name: "HumidityAvg",
                table: "DailyForecasts",
                newName: "UvIndex");

            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "DailyForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

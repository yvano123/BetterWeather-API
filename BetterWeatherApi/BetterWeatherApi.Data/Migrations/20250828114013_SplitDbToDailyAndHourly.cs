using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterWeatherApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SplitDbToDailyAndHourly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts");

            migrationBuilder.RenameTable(
                name: "Forecasts",
                newName: "WeatherForecastEntity");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "WeatherForecastEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecastEntity",
                table: "WeatherForecastEntity",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecastEntity",
                table: "WeatherForecastEntity");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "WeatherForecastEntity");

            migrationBuilder.RenameTable(
                name: "WeatherForecastEntity",
                newName: "Forecasts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterWeatherApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class extraDataAddedForWeatherResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "WindSpeed",
                table: "HourlyForecasts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WindSpeed",
                table: "DailyForecasts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "HourlyForecasts");

            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "DailyForecasts");
        }
    }
}

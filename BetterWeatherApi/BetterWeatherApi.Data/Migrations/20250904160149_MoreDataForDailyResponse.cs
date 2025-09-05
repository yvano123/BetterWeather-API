using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterWeatherApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreDataForDailyResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WindSpeed",
                table: "DailyForecasts",
                newName: "WindSpeedAvg");

            migrationBuilder.AddColumn<int>(
                name: "UvIndexAvg",
                table: "DailyForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UvIndexAvg",
                table: "DailyForecasts");

            migrationBuilder.RenameColumn(
                name: "WindSpeedAvg",
                table: "DailyForecasts",
                newName: "WindSpeed");
        }
    }
}

# BetterWeather-Api

## Prerequisites

-   Visual Studio 2022 with the C# workload installed
-   .NET 8 SDK (or later)
-   SQL Server (LocalDB or full installation)

---

## Running the API

1. Clone this repository and navigate to:  
   `BetterWeather-API\BetterWeatherApi\BetterWeatherApi.Web`

2. Make sure all projects are loaded.

3. Ensure the startup project is set to **BetterWeatherApi.Web**.

4. Install the Entity Framework CLI tool (if not already installed):  
   `dotnet tool install --global dotnet-ef`

5. Install SQL Server LocalDB via the Visual Studio installer in the Individual Components tab.

6. In the installer, select the **Basic** installation option.

7. Restart your computer.

8. Set up the database by running:  
   `dotnet ef database update --project ../BetterWeatherApi.Data`

9. Open the `appsettings.json` file and ensure it looks like this:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BetterWeather;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
  },
  "AllowedHosts": "*",
  "TomorrowApiKey": YOUR_TOMORROW_API_KEY,
  "ImageApiKey": YOUR_IMAGE_API_KEY
}
```

10. Fill in the fields **TomorrowApiKey** and **ImageApiKey** with the provided keys.

11. Start the application by running:  
    `dotnet run`

---

## Choices & Motivation

-   **Language**: I chose **C#** because I was already familiar with it and had prior experience building APIs during school and my internship.
-   **Data storage**: I cache responses from the **Tomorrow.io API** because it has a limit of 25 requests per hour. New data is only fetched if more than 30 minutes have passed since the last request for the same location.
-   **Database**: I used a local **SQL Server** database with **Entity Framework Core**. Since I had little prior experience with EF Core, getting it to work was challenging but valuable to learn.

---

## Known Limitations

1. Due to the 25 requests per hour limit on the Tomorrow.io API, data may sometimes be unavailable for certain locations.
2. The API does not currently adjust for timezones when returning data, so timestamps may be inaccurate.

---

## Future Improvements

1. Automatically determine and return the correct timezone for requested locations.

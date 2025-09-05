# BetterWeather-Api

## Running the API

1. Clone this repository and navigate to:  
   `BetterWeather-API\BetterWeatherApi\BetterWeatherApi.Web`

2. Set up the database by running:  
   `dotnet ef database update --project ../BetterWeatherApi.Data`

3. Open the `appsettings.json` file and make sure it looks like this:

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

4. Fill in the fields `TomorrowApiKey` and `ImageApiKey` with the provided keys.

5. Start the application by running:  
   dotnet run

---

## Choices & Motivation

-   **Language**: I used **C#** because I was already familiar with it and had experience building APIs during school and my internship.
-   **Data storage**: I cache responses from the **Tomorrow.io API** because it has a limit of 25 requests per hour. New data is fetched only if more than 30 minutes have passed since the last request for a specific location.
-   **Database**: I used a local **SQL Server** database with **Entity Framework Core**. Since I don’t have much experience with EF Core, getting it to work was quite challenging.

---

## Known Limitations

1. Due to the 25 requests per hour limit on the Tomorrow.io API, data may occasionally be unavailable for certain locations.
2. The API does not currently calculate timezones for requested locations, making the returned time data inaccurate.

---

## Future Improvements

1. Automatically detect and return the correct timezone for requested locations.

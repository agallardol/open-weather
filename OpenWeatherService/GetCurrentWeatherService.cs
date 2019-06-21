using Microsoft.Rest;
using OpenWeatherDataStore;
using OpenWeatherDataStore.Models;
using OpenWeatherMapApi;
using OpenWeatherMapApi.Models;
using OpenWeatherService.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherService
{
    public partial class GetCurrentWeatherService : ServiceBase
    {
        string openWeatherMapAppId;
        string openWeatherMapBaseAddress;
        string openWeatherDataPersistenceClientFilePath;
        readonly LocationService locationService = new LocationService();
        CurrentWeatherService currentWeatherService;
        OpenWeatherDataStoreClient openWeatherDataPersistenceClient;

        public GetCurrentWeatherService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// args[0] represent OpenWeatherMapApiClientUri. Ex: https://api.openweathermap.org/data/2.5/
        /// args[1] represent OpenWeatherMapApiClientAppId Ex: 63d35ff6068c3103ccd1227526935675
        /// args[2] represent OpenWeatherDataPersistenceClientFilePath Ex: C://Users/Agallardol/Documents/database.db
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            openWeatherMapBaseAddress = args[0];
            openWeatherMapAppId = args[1];
            openWeatherDataPersistenceClientFilePath = args[2];

            currentWeatherService = new CurrentWeatherService(openWeatherMapBaseAddress, openWeatherMapAppId);
            openWeatherDataPersistenceClient = new OpenWeatherDataStoreClient(openWeatherDataPersistenceClientFilePath);

            EventLog.WriteEntry($"Service started\nOpenWeatherMapAddress: {openWeatherMapBaseAddress}\nOpenWeatherMapAppId: {openWeatherMapAppId}", EventLogEntryType.Information);

            GeoCoordinate currentGeoCoordinate = locationService.GetCurrentGeoCoordinate().Result;
            EventLog.WriteEntry($"GeoCoordinate\n Latitude: {currentGeoCoordinate.Latitude}\n Longitude: {currentGeoCoordinate.Longitude}", EventLogEntryType.Information);


            WeatherData weatherData = currentWeatherService.GetCurrentWeather(currentGeoCoordinate.Latitude, currentGeoCoordinate.Longitude).Result;
            EventLog.WriteEntry($"Weather data\n Country: {weatherData.Sys.Country}\n Location: {weatherData.Name}\n Temp: {weatherData.Main.Temp}", EventLogEntryType.Information);

            openWeatherDataPersistenceClient.AddWeatherData(new WeatherDataModel()
            {
                Latitude = currentGeoCoordinate.Latitude,
                Longitude = currentGeoCoordinate.Longitude,
                Temp = weatherData.Main.Temp.Value,
                Location = weatherData.Name,
                Country = weatherData.Sys.Country
            });
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Service stoped", EventLogEntryType.Information);
        }

    }
}

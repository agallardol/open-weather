using OpenWeatherDataStore.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherDataStore
{
    public class OpenWeatherDataStoreClient : IOpenWeatherDataStoreClient
    {
        readonly SQLiteConnection db;
        public OpenWeatherDataStoreClient(string dataStoreFilePath)
        {
            this.db = new SQLiteConnection(dataStoreFilePath);
            db.CreateTable<WeatherDataModel>();
        }

        public void AddWeatherData(WeatherDataModel weatherData)
        {
            weatherData.CreatedAt = DateTime.UtcNow;
            this.db.Insert(weatherData);
        }

        public WeatherDataModel GetLastWeatherData()
        {
            return this.db.Query<WeatherDataModel>($"SELECT * FROM {nameof(WeatherDataModel)} ORDER BY {nameof(WeatherDataModel.CreatedAt)} DESC LIMIT 1").FirstOrDefault();
        }
    }
}

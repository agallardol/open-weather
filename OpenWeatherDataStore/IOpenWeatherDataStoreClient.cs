using OpenWeatherDataStore.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherDataStore
{
    public interface IOpenWeatherDataStoreClient
    {
        void AddWeatherData(WeatherDataModel weatherData);

        WeatherDataModel GetLastWeatherData();
    }
}

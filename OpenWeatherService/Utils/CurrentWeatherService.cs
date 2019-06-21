using Microsoft.Rest;
using OpenWeatherMapApi;
using OpenWeatherMapApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherService.Utils
{
    public class CurrentWeatherService
    {
        readonly OpenWeatherMapApiClient openWeatherMapApiClient;

        public CurrentWeatherService(string openWeatherMapBaseAddress, string openWeatherMapAppId)
        {
            openWeatherMapApiClient = new OpenWeatherMapApiClient(new Uri(openWeatherMapBaseAddress), new AddAppIdMessageHandler(openWeatherMapAppId));
        }

        public async Task<WeatherData> GetCurrentWeather(double latitutde, double longitude)
        {
            try
            {
                HttpOperationResponse<object> httpOperationResponse = await openWeatherMapApiClient.CurrentWeatherDataWithHttpMessagesAsync(
                       lat: latitutde.ToString(),
                       lon: longitude.ToString(),
                       units: "metric"
                   );

                if (httpOperationResponse.Response.IsSuccessStatusCode)
                {
                    WeatherData weatherData = httpOperationResponse.Body as WeatherData;
                    return weatherData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

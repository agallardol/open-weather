// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace OpenWeatherMapApi.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Main
    /// </summary>
    public partial class Main
    {
        /// <summary>
        /// Initializes a new instance of the Main class.
        /// </summary>
        public Main()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Main class.
        /// </summary>
        /// <param name="temp">Temperature. Unit Default: Kelvin, Metric:
        /// Celsius, Imperial: Fahrenheit.</param>
        /// <param name="pressure">Atmospheric pressure (on the sea level, if
        /// there is no sea_level or grnd_level data), hPa</param>
        /// <param name="humidity">Humidity, %</param>
        /// <param name="tempMin">Minimum temperature at the moment. This is
        /// deviation from current temp that is possible for large cities and
        /// megalopolises geographically expanded (use these parameter
        /// optionally). Unit Default: Kelvin, Metric: Celsius, Imperial:
        /// Fahrenheit.</param>
        /// <param name="tempMax">Maximum temperature at the moment. This is
        /// deviation from current temp that is possible for large cities and
        /// megalopolises geographically expanded (use these parameter
        /// optionally). Unit Default: Kelvin, Metric: Celsius, Imperial:
        /// Fahrenheit.</param>
        /// <param name="seaLevel">Atmospheric pressure on the sea level,
        /// hPa</param>
        /// <param name="grndLevel">Atmospheric pressure on the ground level,
        /// hPa</param>
        public Main(double? temp = default(double?), int? pressure = default(int?), int? humidity = default(int?), double? tempMin = default(double?), double? tempMax = default(double?), double? seaLevel = default(double?), double? grndLevel = default(double?))
        {
            Temp = temp;
            Pressure = pressure;
            Humidity = humidity;
            TempMin = tempMin;
            TempMax = tempMax;
            SeaLevel = seaLevel;
            GrndLevel = grndLevel;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets temperature. Unit Default: Kelvin, Metric: Celsius,
        /// Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty(PropertyName = "temp")]
        public double? Temp { get; set; }

        /// <summary>
        /// Gets or sets atmospheric pressure (on the sea level, if there is no
        /// sea_level or grnd_level data), hPa
        /// </summary>
        [JsonProperty(PropertyName = "pressure")]
        public int? Pressure { get; set; }

        /// <summary>
        /// Gets or sets humidity, %
        /// </summary>
        [JsonProperty(PropertyName = "humidity")]
        public int? Humidity { get; set; }

        /// <summary>
        /// Gets or sets minimum temperature at the moment. This is deviation
        /// from current temp that is possible for large cities and
        /// megalopolises geographically expanded (use these parameter
        /// optionally). Unit Default: Kelvin, Metric: Celsius, Imperial:
        /// Fahrenheit.
        /// </summary>
        [JsonProperty(PropertyName = "temp_min")]
        public double? TempMin { get; set; }

        /// <summary>
        /// Gets or sets maximum temperature at the moment. This is deviation
        /// from current temp that is possible for large cities and
        /// megalopolises geographically expanded (use these parameter
        /// optionally). Unit Default: Kelvin, Metric: Celsius, Imperial:
        /// Fahrenheit.
        /// </summary>
        [JsonProperty(PropertyName = "temp_max")]
        public double? TempMax { get; set; }

        /// <summary>
        /// Gets or sets atmospheric pressure on the sea level, hPa
        /// </summary>
        [JsonProperty(PropertyName = "sea_level")]
        public double? SeaLevel { get; set; }

        /// <summary>
        /// Gets or sets atmospheric pressure on the ground level, hPa
        /// </summary>
        [JsonProperty(PropertyName = "grnd_level")]
        public double? GrndLevel { get; set; }

    }
}

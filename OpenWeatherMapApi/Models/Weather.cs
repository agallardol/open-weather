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
    /// Weather
    /// </summary>
    public partial class Weather
    {
        /// <summary>
        /// Initializes a new instance of the Weather class.
        /// </summary>
        public Weather()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Weather class.
        /// </summary>
        /// <param name="id">Weather condition id</param>
        /// <param name="main">Group of weather parameters (Rain, Snow, Extreme
        /// etc.)</param>
        /// <param name="description">Weather condition within the
        /// group</param>
        /// <param name="icon">Weather icon id</param>
        public Weather(int? id = default(int?), string main = default(string), string description = default(string), string icon = default(string))
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets weather condition id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        /// <summary>
        /// Gets or sets weather condition within the group
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets weather icon id
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

    }
}

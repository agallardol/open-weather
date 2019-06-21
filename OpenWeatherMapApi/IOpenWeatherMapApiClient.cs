// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace OpenWeatherMapApi
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Get current weather, daily forecast for 16 days, and 3-hourly forecast
    /// 5 days for your city. Helpful stats, graphics, and this day in history
    /// charts are available for your reference. Interactive maps show
    /// precipitation, clouds, pressure, wind around your location stations.
    /// Data is available in JSON, XML, or HTML format. **Note**: This sample
    /// Swagger file covers the `current` endpoint only from the OpenWeatherMap
    /// API. &lt;br/&gt;&lt;br/&gt; **Note**: All parameters are optional, but
    /// you must select at least one parameter. Calling the API by city ID
    /// (using the `id` parameter) will provide the most precise location
    /// results.
    /// </summary>
    public partial interface IOpenWeatherMapApiClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Client API version.
        /// </summary>
        string ApiVersion { get; }


        /// <summary>
        /// Call current weather data for one location
        /// </summary>
        /// <remarks>
        /// Access current weather data for any location on Earth including
        /// over 200,000 cities! Current weather is frequently updated based on
        /// global models and data from more than 40,000 weather stations.
        /// </remarks>
        /// <param name='q'>
        /// **City name**. *Example: London*. You can call by city name, or by
        /// city name and country code. The API responds with a list of results
        /// that match a searching word. For the query value, type the city
        /// name and optionally the country code divided by comma; use ISO 3166
        /// country codes.
        /// </param>
        /// <param name='id'>
        /// **City ID**. *Example: `2172797`*. You can call by city ID. API
        /// responds with exact result. The List of city IDs can be downloaded
        /// [here](http://bulk.openweathermap.org/sample/). You can include
        /// multiple cities in parameter &amp;mdash; just separate them by
        /// commas. The limit of locations is 20. *Note: A single ID counts as
        /// a one API call. So, if you have city IDs. it's treated as 3 API
        /// calls.*
        /// </param>
        /// <param name='lat'>
        /// **Latitude**. *Example: 35*. The latitude cordinate of the location
        /// of your interest. Must use with `lon`.
        /// </param>
        /// <param name='lon'>
        /// **Longitude**. *Example: 139*. Longitude cordinate of the location
        /// of your interest. Must use with `lat`.
        /// </param>
        /// <param name='zip'>
        /// **Zip code**. Search by zip code. *Example: 95050,us*. Please note
        /// if country is not specified then the search works for USA as a
        /// default.
        /// </param>
        /// <param name='units'>
        /// **Units**. *Example: imperial*. Possible values: `metric`,
        /// `imperial`. When you do not use units parameter, format is
        /// `standard` by default. Possible values include: 'standard',
        /// 'metric', 'imperial'
        /// </param>
        /// <param name='lang'>
        /// **Language**. *Example: en*. You can use lang parameter to get the
        /// output in your language. We support the following languages that
        /// you can use with the corresponded lang values: Arabic - `ar`,
        /// Bulgarian - `bg`, Catalan - `ca`, Czech - `cz`, German - `de`,
        /// Greek - `el`, English - `en`, Persian (Farsi) - `fa`, Finnish -
        /// `fi`, French - `fr`, Galician - `gl`, Croatian - `hr`, Hungarian -
        /// `hu`, Italian - `it`, Japanese - `ja`, Korean - `kr`, Latvian -
        /// `la`, Lithuanian - `lt`, Macedonian - `mk`, Dutch - `nl`, Polish -
        /// `pl`, Portuguese - `pt`, Romanian - `ro`, Russian - `ru`, Swedish -
        /// `se`, Slovak - `sk`, Slovenian - `sl`, Spanish - `es`, Turkish -
        /// `tr`, Ukrainian - `ua`, Vietnamese - `vi`, Chinese Simplified -
        /// `zh_cn`, Chinese Traditional - `zh_tw`. Possible values include:
        /// 'ar', 'bg', 'ca', 'cz', 'de', 'el', 'en', 'fa', 'fi', 'fr', 'gl',
        /// 'hr', 'hu', 'it', 'ja', 'kr', 'la', 'lt', 'mk', 'nl', 'pl', 'pt',
        /// 'ro', 'ru', 'se', 'sk', 'sl', 'es', 'tr', 'ua', 'vi', 'zh_cn',
        /// 'zh_tw'
        /// </param>
        /// <param name='mode'>
        /// **Mode**. *Example: html*. Determines format of response. Possible
        /// values are `xml` and `html`. If mode parameter is empty the format
        /// is `json` by default. Possible values include: 'json', 'xml',
        /// 'html'
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CurrentWeatherDataWithHttpMessagesAsync(string q = default(string), string id = default(string), string lat = default(string), string lon = default(string), string zip = "94040,us", string units = default(string), string lang = default(string), string mode = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}

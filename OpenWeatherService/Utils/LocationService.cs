using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherService.Utils
{
    public class LocationService
    {
        readonly GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        public Task<GeoCoordinate> GetCurrentGeoCoordinate()
        {
            TaskCompletionSource<GeoCoordinate> tcs = new TaskCompletionSource<GeoCoordinate>();
            geoCoordinateWatcher.PositionChanged += (object sender, GeoPositionChangedEventArgs<System.Device.Location.GeoCoordinate> e) => {
                if (!e.Position.Location.IsUnknown && tcs.TrySetResult(e.Position.Location))
                {
                    geoCoordinateWatcher.Stop();
                }
            };
            if (!geoCoordinateWatcher.TryStart(true, new TimeSpan(0, 0, 15)))
            {
                tcs.SetException(new InvalidOperationException("It was not possible to obtain the location of the device"));
            }
            return tcs.Task;
        }
    }
}

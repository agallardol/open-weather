using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OpenWeatherApp.Services
{
    public class GetCurrentWeatherServiceController : IGetCurrentWeatherServiceController
    {
        readonly ServiceController serviceController;
        readonly string[] args;
        public GetCurrentWeatherServiceController(string openWeatherMapApiBaseAddress, string openWeatherMapApiAppId, string dataStoreFilePath, string getCurrentWeatherServiceName)
        {
            args = new[] { openWeatherMapApiBaseAddress, openWeatherMapApiAppId, dataStoreFilePath };
            serviceController = new ServiceController(getCurrentWeatherServiceName);
        }

        public bool CanBeStarted {
            get {
                serviceController.Refresh();
                return serviceController.Status == ServiceControllerStatus.Stopped;
            }
        }

        public bool CanBeStopped {
            get
            {
                serviceController.Refresh();
                return serviceController.Status == ServiceControllerStatus.Running;
            }
        }

        public void StartService()
        {
            serviceController.Start(args);
        }

        public void StopService()
        {
            serviceController.Stop();
        }
    }
}

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
    public class GetCurrentWeatherServiceController : ICustomServiceController
    {
        readonly ServiceController serviceController;
        readonly string[] args;
        const int REFRESH_RATE = 500;
        Timer refreshTimer;
        ServiceControllerStatus lastStatus;
        public GetCurrentWeatherServiceController(string openWeatherMapApiBaseAddress, string openWeatherMapApiAppId, string dataStoreFilePath, string getCurrentWeatherServiceName)
        {
            refreshTimer = new Timer(500);
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Start();
            args = new[] { openWeatherMapApiBaseAddress, openWeatherMapApiAppId, dataStoreFilePath };
            serviceController = new ServiceController(getCurrentWeatherServiceName);
            lastStatus = serviceController.Status;
        }

        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            serviceController.Refresh();
            if(lastStatus != serviceController.Status)
            {
                lastStatus = serviceController.Status;
                StatusChanged?.Invoke(this, new EventArgs());
            }
        }

        public bool CanBeStarted {
            get {
                return serviceController.Status == ServiceControllerStatus.Stopped;
            }
        }

        public bool CanBeStopped {
            get
            {
                return serviceController.Status == ServiceControllerStatus.Running;
            }
        }

        public event EventHandler StatusChanged;

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

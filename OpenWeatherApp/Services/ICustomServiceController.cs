using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherApp.Services
{
    public interface ICustomServiceController
    {
        bool CanBeStarted { get; }
        bool CanBeStopped { get; }
        event EventHandler StatusChanged;
        void StartService();
        void StopService();
    }
}

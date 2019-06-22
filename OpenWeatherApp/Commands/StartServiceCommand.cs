using OpenWeatherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace OpenWeatherApp.Commands
{
    public class StartServiceCommand : RelayCommand
    {
        public StartServiceCommand(ICustomServiceController customServiceController): base(o => customServiceController.StartService(), o => customServiceController.CanBeStarted)
        {
            customServiceController.StatusChanged += CustomServiceController_StatusChanged;
        }

        private void CustomServiceController_StatusChanged(object sender, EventArgs e)
        {
            OnCanExecuteChange();
        }
    }
}

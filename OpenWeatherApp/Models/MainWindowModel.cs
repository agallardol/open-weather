using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherApp.Models
{
    public class MainWindowModel
    {
        public string Location { get; set; }

        public string Country { get; set; }

        public double Temp { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}

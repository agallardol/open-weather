﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherDataStore.Models
{
    public class WeatherDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Temp { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Informate.Models
{
    public class WeatherModel
    {
        public decimal temperature { get; set; }
        public string icon { get; set; }

        public string description { get; set; }
        public decimal minTemperature { get; set; }

        public decimal maxTemperature { get; set; }

        public string country { get; set; }

        public string city { get; set; }
    }
}

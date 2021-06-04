using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Informate.Models
{
    public class WeatherAndNewsModel
    {
        public List<NewsModel> news { get; set; }

        public WeatherModel weather { get; set; }
    }
}

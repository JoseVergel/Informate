using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Informate.Models
{
    public class NewsModel
    {
        public string title { get; set; }

        public string description { get; set; }
        public string urlImg { get; set; }

        public string urlNews { get; set; }

        public DateTime publishedAt { get; set; }

        public static implicit operator NewsModel(List<NewsModel> v)
        {
            throw new NotImplementedException();
        }
    }
}

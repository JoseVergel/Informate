using Informate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Informate.Controllers
{
    public class WeatherController
    {
       
        public async  Task<WeatherModel> LoadWeather(string city) {

            WeatherModel weather = new WeatherModel();

            using (var client = new HttpClient()) {

                //client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string apiKey = "797729e825cd783b95629c675c291bef";
                string lang = "es";
                string units = "metric";
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&lang={lang}&units={units}";
                Console.WriteLine(url);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                   
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = response.Content.ReadAsStringAsync().Result;                    
                    Console.WriteLine(json); 
                    //Se convierte resultado
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);                   
                    

                    weather.icon           = (string)  jsonObject["weather"][0].icon;
                    weather.temperature    = (decimal) jsonObject["main"]["temp"];
                    weather.description    = (string)  jsonObject["weather"][0].description;
                    weather.minTemperature = (decimal) jsonObject["main"]["temp_min"];
                    weather.maxTemperature = (decimal) jsonObject["main"]["temp_max"];
                    weather.country        = (string)  jsonObject["sys"].country;
                    weather.city           = (string)  jsonObject.name;                    

                }
                else {
                    Console.WriteLine("no recibe respuesta correcta de api");
                }

                Console.WriteLine("termina controlador");
            }

            return weather;
        }
    }
}

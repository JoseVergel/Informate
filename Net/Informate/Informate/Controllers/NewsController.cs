using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Informate.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace Informate.Controllers
{
    public class NewsController : Controller
    {
        public async Task<List<NewsModel>> LoadNews(string country)
        {           

            List < NewsModel > allNews = new List<NewsModel>();
            NewsModel news = new NewsModel();

            using (var client = new HttpClient())
            {
                             
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string apiKey = "bc52bfba94dc487899df3d1cf8778846";
                
                string url = $"https://newsapi.org/v2/top-headlines?country={country}&apiKey={apiKey}";
                Console.WriteLine(url);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = response.Content.ReadAsStringAsync().Result;
                   
                    dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                    // Se extraen articulos
                    JArray articles = jsonObject["articles"];                    
                    // Cantidad de articulos                  
                    int totalResults = articles.Count;
                    
                    Console.WriteLine("totalResults: " + totalResults);
                    

                    for (int i = 0; i < totalResults ; i++)
                    {
                        news= new NewsModel();
                        news.title       = (string)   jsonObject["articles"][i].title;
                        news.description = (string)   jsonObject["articles"][i].description;
                        news.urlNews     = (string)   jsonObject["articles"][i].url;
                        news.urlImg      = (string)   jsonObject["articles"][i].urlToImage;
                        news.publishedAt = (DateTime) jsonObject["articles"][i].publishedAt;
                    
                        allNews.Add(news);
                    }
                    Console.WriteLine("Lista de noticias procesadas");

                }
                else
                {
                    Console.WriteLine("no recibe respuesta correcta de api");
                }

                Console.WriteLine("termina controlador");
            }

            return allNews;
        }
    }
}

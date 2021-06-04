using Informate.Context;
using Informate.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Informate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InformateController : ControllerBase
    {
        private readonly AppDbContext context;
        public InformateController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{city}")]
        public ActionResult Get(string city) {
            try
            {
                if (!string.IsNullOrEmpty(city)){

                    WeatherController weatherProcessor = new WeatherController();
                    //Se obtiene información del clima desde api
                    var weather = (weatherProcessor.LoadWeather(city)).Result;
                    var allNews = new List<NewsModel>();

                    NewsController newsProcessor = new NewsController();
                    if (!string.IsNullOrEmpty(weather.country))
                    {
                        //Se obtienen noticias del pais desde api
                        allNews = (newsProcessor.LoadNews(weather.country)).Result;

                    }
                    
                    //Se unifica información
                    WeatherAndNewsModel all = new WeatherAndNewsModel();
                    all.news    = allNews;
                    all.weather = weather;

                    
                    //Se convierten datos a json
                    string output = JsonConvert.SerializeObject(all);
                    
                   

                    //Se almacena historico de búsqueda
                    HistoricoBD historico       = new HistoricoBD();
                    historico.Ciudad            = weather.city.ToUpper();
                    historico.temperatura       = weather.temperature;
                    historico.Fecha_busqueda    = DateTime.Now;
                    HistoricoController histo   = new HistoricoController(context);

                    histo.Create(historico);
                    return Ok(output);
                }
                else {
                    return BadRequest("El campo ciudad es obligatorio");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

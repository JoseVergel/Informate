using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Informate.Context;
using Informate.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Informate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly AppDbContext context;
        public HistoricoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet()]
        public ActionResult Get() {
            try
            {
                return Ok(context.Historico.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public int Create(HistoricoBD historico) {
            int id = -1;
            try
            {
              
                Console.WriteLine(historico.Ciudad);                
                //Se valida si la ciudad ya existe en historico
                HistoricoBD oldHistorico = context.Historico.Where(b => b.Ciudad.ToUpper() == historico.Ciudad.ToUpper()).SingleOrDefault();
                

                if (oldHistorico != null ){
                    //Si la ciudad existe en el histórico se actualiza fecha de búsqueda

                    oldHistorico.Fecha_busqueda       = DateTime.Now;
                    oldHistorico.temperatura          = historico.temperatura;
                    context.Entry(oldHistorico).State = EntityState.Modified;
                    context.SaveChanges();
                    Console.WriteLine("Se actualiza ciudad en BD");
                }
                else {
                   

                    historico.Ciudad = CapitalizeFirstLetter(historico.Ciudad);

                    context.Historico.Add(historico);
                    context.SaveChanges();
                    id = historico.idHistorico;
                    Console.WriteLine("Se ingresa ciudad a BD");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return id;
        }

        public string CapitalizeFirstLetter(string word) {

            if (string.IsNullOrEmpty(word)){
                return string.Empty;
            }

            char FistLetter = char.ToUpper(word[0]);            

            return FistLetter+ word.Substring(1).ToLower();       
           
        }   

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Informate.Models
{
    public class HistoricoBD
    {
        [Key]
        public int idHistorico { get; set; }
        public string Ciudad { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal temperatura { get; set; }
        public DateTime Fecha_busqueda { get; set; }
    }
}

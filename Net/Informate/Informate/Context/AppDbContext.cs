using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Informate.Models;
using Microsoft.EntityFrameworkCore;

namespace Informate.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<HistoricoBD> Historico { get; set; }
    }
}

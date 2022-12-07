using Microsoft.EntityFrameworkCore;
using Mundo_de_Sombras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mundo_de_Sombras.Data
{
    public class Mundo_de_SombrasContext : DbContext
    {

        public Mundo_de_SombrasContext(DbContextOptions<Mundo_de_SombrasContext> options) : base(options)
        {

        }

        public DbSet<Libros> Libros { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Recomendados_de_la_semana> Recomendados_de_la_semana { get; set; }
        public DbSet<Nuevos_libros> nuevos_libros {get; set;}
        public DbSet<Mas_comprados> Mas_comprados { get; set; }

    }



        
}

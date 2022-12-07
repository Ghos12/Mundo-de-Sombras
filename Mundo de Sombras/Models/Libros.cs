using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mundo_de_Sombras.Models
{
    public class Libros
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public decimal Numero_de_descargas { get; set; }

        public decimal Puntuacion { get; set; }

        public decimal Precio { get; set; }
    }
}

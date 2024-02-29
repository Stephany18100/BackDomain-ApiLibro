using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class LibroResponse
    {
        public string NombreLibro { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string PaisAutor { get; set; }
        public int NumeroDePaginas { get; set; }
        public DateTime AnioDeEdicion { get; set; }
        public decimal Precio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prestamo
    {
        [Key]
        public int NumeroPedido { get; set; }
        [ForeignKey("Libro")]
        public int FKCodigoLibro { get; set; }
        [ForeignKey("Usuario")]
        public int? FKCodigoUsuario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaMaximaDevolver { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}

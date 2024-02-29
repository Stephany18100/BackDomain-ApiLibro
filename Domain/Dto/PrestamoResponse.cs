using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PrestamoResponse
    {
        public int FKCodigoLibro { get; set; }
        public int FKCodigoUsuario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaMaximaDevolver { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}

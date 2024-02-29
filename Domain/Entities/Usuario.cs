using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string? DNI { get; set; }
        public string Domicilio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}

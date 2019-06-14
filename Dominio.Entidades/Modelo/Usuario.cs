using Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Tienda
{
    public class Usuario: EntidadBase
    {
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public bool Estado { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
        public string Contraseña { get; set; }
    }
}

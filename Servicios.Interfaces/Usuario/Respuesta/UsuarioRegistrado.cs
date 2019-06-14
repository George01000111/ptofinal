using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Usuario.Respuesta
{
    public class UsuarioRegistrado
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public int RolId { get; set; }
        public bool Estado { get; set; }
        public string Contraseña { get; set; }
    }
}

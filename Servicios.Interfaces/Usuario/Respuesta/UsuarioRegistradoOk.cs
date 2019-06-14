using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Usuario.Respuesta
{
    public class UsuarioRegistradoOk
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }


        [Required(ErrorMessage = "Ingrese fecha de Inicio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
        public string Contraseña { get; set; }

    }
}

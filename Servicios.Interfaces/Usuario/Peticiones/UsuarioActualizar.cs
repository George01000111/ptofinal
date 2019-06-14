using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Usuario.Peticiones
{
    public class UsuarioActualizar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el Nombre de Usuario")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese los Apellidos")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Ingrese los Nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Ingrese fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese el telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese el Estado Civil")]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "Ingrese el rol")]
        public int RolId { get; set; }
        public bool Estado { get; set; }
        public string Contraseña { get; set; }
    }
}

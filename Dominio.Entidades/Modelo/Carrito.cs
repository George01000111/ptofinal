using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{

    public class Carrito : EntidadBase
    {
       
        public string NombreUsuario { get; set; }
        public string NombreProd { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    }

}

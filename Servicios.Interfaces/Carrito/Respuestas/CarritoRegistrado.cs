using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Carrito.Respuestas
{
    public class CarritoRegistrado
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreProd { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}

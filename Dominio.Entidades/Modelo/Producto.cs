using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dominio.Entidades.Modelo
{
    public class Producto : EntidadBase
    {


        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        public bool Estado { get; set; }
        public int Stock { get; set; }


    }
}

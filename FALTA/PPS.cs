using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public  class PPS
    {
        public int ID { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        [ForeignKey("PS")]
        public int IdPedido { get; set; }
        public string Observacion { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual PS PS { get; set; }
    }
}

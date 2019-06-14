using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class Productos_Pedidos
    {
        public int ID { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        [DisplayName("Anotaciones extras")]
        public string Observacion { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}

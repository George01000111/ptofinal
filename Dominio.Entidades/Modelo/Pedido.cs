using Dominio.Entidades.Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class Pedido
    {
      
        public Pedido()
        {
            this.DetalleBoleta = new HashSet<DetalleBoleta>();
            this.Productos_Pedido = new HashSet<Productos_Pedidos>();
        }

        public int ID { get; set; }

        public bool Atendido { get; set; }
  
        public string Detalle { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        
        public virtual ICollection<DetalleBoleta> DetalleBoleta { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Productos_Pedidos> Productos_Pedido { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
   public class DetalleBoleta
    {

        public int ID { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        [DisplayName("Monto Total")]
        public decimal MontoTotal { get; set; }
        [ForeignKey("ModoDePago")]
        public int IdModoDePago { get; set; }

        public virtual ModoDePago ModoDePago { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}

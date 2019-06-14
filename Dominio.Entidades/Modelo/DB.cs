using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class DB
    {

        public int ID { get; set; }

       
        public int IdPedido { get; set; }
        public decimal MontoTotal { get; set; }
        [ForeignKey("ModoDePago")]
        public int IdModoDePago { get; set; }

        public virtual ModoDePago ModoDePago { get; set; }
       
    }
}

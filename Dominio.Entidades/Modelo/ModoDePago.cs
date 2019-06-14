using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class ModoDePago
    {

        public ModoDePago()
        {
            this.DetalleBoleta = new HashSet<DetalleBoleta>();
            this.DB = new HashSet<DB>();
        }

        public int ID { get; set; }
        [DisplayName("Modo de Pago")]
        public string Descripcion { get; set; }

        public virtual ICollection<DetalleBoleta> DetalleBoleta { get; set; }
        public virtual ICollection<DB> DB { get; set; }

    }
}

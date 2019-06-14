using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class PS
    {
        public PS()
        {
            this.DB = new HashSet<DB>();
            this.PPS = new HashSet<PPS>();
        }

        public int ID { get; set; }
        public Nullable<bool> Atendido { get; set; }
        public string Detalle { get; set; }
        public virtual ICollection<DB> DB { get; set; }
        public virtual ICollection<PPS> PPS { get; set; }

    }
}

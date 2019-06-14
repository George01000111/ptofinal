using Dominio.Entidades.Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Modelo
{
    public class Rol : EntidadBase
    {
        public Rol() : base()
        {
            this.Usuario = new HashSet<Usuario>();
        }

        public string descripcion { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}

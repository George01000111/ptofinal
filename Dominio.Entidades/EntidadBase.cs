using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EntidadBase
    {
        public int Id { get; set; }
        public DateTime DiaDeCreacion { get; set; }
        public DateTime UltimaDiaDeEdicion { get; set; }
     
        public EntidadBase()
        {
            this.DiaDeCreacion = DateTime.Now;
            this.UltimaDiaDeEdicion = DateTime.Now;
      
        }
    }
}

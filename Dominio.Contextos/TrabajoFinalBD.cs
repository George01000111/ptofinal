using Dominio.Entidades.Modelo;
using Dominio.Entidades.Tienda;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contextos
{
   public class TrabajoFinalBD : DbContext
    {
        private static readonly string NOMBRE_CADENA_CONEXION = "TrabajoFinal";

        public TrabajoFinalBD() : base(NOMBRE_CADENA_CONEXION) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rol { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<DB> DB { get; set; }
        public DbSet<DetalleBoleta> DetalleBoleta { get; set; }
        public DbSet<ModoDePago> ModoDePago { get; set; }
      
        public DbSet<Pedido> Pedido { get; set; }
        
        public DbSet<Productos_Pedidos> Productos_Pedidos { get; set; }
       public DbSet<PS> PS { get; set; }
      public DbSet<PPS> PPS { get; set; }
      public DbSet<Carrito> Carrito { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}

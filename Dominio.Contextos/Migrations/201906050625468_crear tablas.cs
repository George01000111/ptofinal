namespace Dominio.Contextos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creartablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DB",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdModoDePago = c.Int(nullable: false),
                        PS_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModoDePago", t => t.IdModoDePago, cascadeDelete: true)
                .ForeignKey("dbo.PS", t => t.PS_ID)
                .Index(t => t.IdModoDePago)
                .Index(t => t.PS_ID);
            
            CreateTable(
                "dbo.ModoDePago",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DetalleBoleta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdModoDePago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModoDePago", t => t.IdModoDePago, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdPedido)
                .Index(t => t.IdModoDePago);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Atendido = c.Boolean(nullable: false),
                        Detalle = c.String(),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Productos_Pedidos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        IdPedido = c.Int(nullable: false),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdPedido);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        ImagePath = c.String(),
                        Estado = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                        DiaDeCreacion = c.DateTime(nullable: false),
                        UltimaDiaDeEdicion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Apellidos = c.String(),
                        Nombres = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.String(),
                        EstadoCivil = c.String(),
                        Estado = c.Boolean(nullable: false),
                        RolId = c.Int(nullable: false),
                        Contraseña = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                        UltimaDiaDeEdicion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                        UltimaDiaDeEdicion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PPS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        IdPedido = c.Int(nullable: false),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.PS", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdPedido);
            
            CreateTable(
                "dbo.PS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Atendido = c.Boolean(),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PPS", "IdPedido", "dbo.PS");
            DropForeignKey("dbo.DB", "PS_ID", "dbo.PS");
            DropForeignKey("dbo.PPS", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.DB", "IdModoDePago", "dbo.ModoDePago");
            DropForeignKey("dbo.DetalleBoleta", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Productos_Pedidos", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.Productos_Pedidos", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.DetalleBoleta", "IdModoDePago", "dbo.ModoDePago");
            DropIndex("dbo.PPS", new[] { "IdPedido" });
            DropIndex("dbo.PPS", new[] { "IdProducto" });
            DropIndex("dbo.Usuario", new[] { "RolId" });
            DropIndex("dbo.Productos_Pedidos", new[] { "IdPedido" });
            DropIndex("dbo.Productos_Pedidos", new[] { "IdProducto" });
            DropIndex("dbo.Pedido", new[] { "IdUsuario" });
            DropIndex("dbo.DetalleBoleta", new[] { "IdModoDePago" });
            DropIndex("dbo.DetalleBoleta", new[] { "IdPedido" });
            DropIndex("dbo.DB", new[] { "PS_ID" });
            DropIndex("dbo.DB", new[] { "IdModoDePago" });
            DropTable("dbo.PS");
            DropTable("dbo.PPS");
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario");
            DropTable("dbo.Producto");
            DropTable("dbo.Productos_Pedidos");
            DropTable("dbo.Pedido");
            DropTable("dbo.DetalleBoleta");
            DropTable("dbo.ModoDePago");
            DropTable("dbo.DB");
        }
    }
}

using AutoMapper;
using Dominio.Entidades.Modelo;
using Dominio.Entidades.Tienda;
using Servicios.Interfaces.Carrito.Peticiones;
using Servicios.Interfaces.Carrito.Respuestas;
using Servicios.Interfaces.Producto.Peticiones;
using Servicios.Interfaces.Producto.Respuestas;
using Servicios.Interfaces.Rol.Peticiones;
using Servicios.Interfaces.Rol.Respuesta;
using Servicios.Interfaces.Usuario.Peticiones;
using Servicios.Interfaces.Usuario.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Transformaciones
{
    public class MapperManagercs
    {
        public static void Initialize()
        {
            Mapper.Initialize(configuration => {

                configuration.CreateMap<Producto, ProductoNuevo>();
                configuration.CreateMap<ProductoNuevo, Producto>();
                configuration.CreateMap< Producto, ProductoActualizar>();
                configuration.CreateMap<Producto, ProductoRegistrado>();



                configuration.CreateMap<Usuario, UsuarioNuevo>();
                configuration.CreateMap<UsuarioNuevo, Usuario>();
                configuration.CreateMap<Usuario, UsuarioActualizar>();
                configuration.CreateMap<Usuario, UsuarioRegistrado>();

                configuration.CreateMap<Rol, RolNuevo>();
                configuration.CreateMap<RolNuevo, Rol>();
                configuration.CreateMap<RolActualizar, Rol>();
                configuration.CreateMap<Rol, RolRegistrado>();

                configuration.CreateMap<Carrito, CarritoNuevo>();
                configuration.CreateMap<CarritoNuevo, Carrito>();
                configuration.CreateMap<Carrito, CarritoActualizar>();
                configuration.CreateMap<Carrito, CarritoRegistrado>();

            });
        }
    }
}

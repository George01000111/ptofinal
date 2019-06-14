using AutoMapper;
using Dominio.Contextos;
using Dominio.Entidades.Modelo;
using Servicios.Interfaces.Carrito;
using Servicios.Interfaces.Carrito.Peticiones;
using Servicios.Interfaces.Carrito.Respuestas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementacion
{
    public class GestorDeCarrito : IGestorDeCarrito
    {
        public CarritoRegistrado Actualizar(CarritoActualizar registroParaActualizar)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                Carrito nuevoCarrito = db.Carrito.Find(registroParaActualizar.Id);
                nuevoCarrito.NombreUsuario = registroParaActualizar.NombreUsuario;
                nuevoCarrito.Precio = registroParaActualizar.Precio;
                nuevoCarrito.NombreProd = registroParaActualizar.NombreProd;
                nuevoCarrito.Cantidad = registroParaActualizar.Cantidad;
             
                db.SaveChanges();
                return Mapper.Map<CarritoRegistrado>(nuevoCarrito);
            }
        }

        public void Borrar(int IdDelRegistro)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                Carrito nuevaLinea = new Carrito() { Id = IdDelRegistro };
                db.Carrito.Attach(nuevaLinea);
                db.Carrito.Remove(nuevaLinea);
                db.SaveChanges();

            }
        }

        public int Count()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Database.ExecuteSqlCommand("select COUNT(Id) from Carrito");

            }
        }

        public List<CarritoRegistrado> Filtrar(CarritoRegistrado registroGuardos)
        {
            throw new NotImplementedException();
        }

        public CarritoActualizar FindById(int Id)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return Mapper.Map<CarritoActualizar>(db.Carrito.Find(Id));
            }
        }

        public List<CarritoRegistrado> Listar()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Carrito.ToList().Select(x => Mapper.Map<CarritoRegistrado>(x)).ToList();
            }
        }

        public List<CarritoRegistrado> ListarXNomb(string Nombre)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Carrito.Where(x => (x.NombreUsuario.Contains(Nombre) ))
            .ToList()
            .Select(x => Mapper.Map<CarritoRegistrado>(x))
            .ToList();
            }
        }

        public IEnumerable<CarritoRegistrado> PagedList(int startRow, int endRow,string nombre)
        {
            IEnumerable<CarritoRegistrado> list;

            if (startRow >= endRow) return new List<CarritoRegistrado>();
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                SqlParameter startRowParam = new SqlParameter("@startRow", startRow);
                SqlParameter endRowParam = new SqlParameter("@endRow", @endRow);
                SqlParameter nombreParam = new SqlParameter("@NombreUsuario", nombre);
                list = db.Database.SqlQuery<CarritoRegistrado>("CarritoPagedList @startRow,@endRow,@NombreUsuario", startRowParam, endRowParam, nombreParam).ToList();

                return list;
            }
        }

        public CarritoRegistrado Registrar(CarritoNuevo registroNuevo)
        {
            Carrito nuevoCarrito = Mapper.Map<Carrito>(registroNuevo);
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                db.Carrito.Add(nuevoCarrito);
                db.SaveChanges();
            }
            return Mapper.Map<CarritoRegistrado>(nuevoCarrito);
        }
    }
}

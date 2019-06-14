using AutoMapper;
using Dominio.Contextos;
using Dominio.Entidades.Modelo;
using Servicios.Interfaces.Producto;
using Servicios.Interfaces.Producto.Peticiones;
using Servicios.Interfaces.Producto.Respuestas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementacion
{
    public class GestorDeProducto : IGestorDeProducto
    {
        public ProductoRegistrado Actualizar(ProductoActualizar registroParaActualizar)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                Producto nuevoProducto = db.Producto.Find(registroParaActualizar.Id);
                nuevoProducto.Nombre = registroParaActualizar.Nombre;
                nuevoProducto.Precio = registroParaActualizar.Precio;
                nuevoProducto.Descripcion = registroParaActualizar.Descripcion;
                nuevoProducto.ImagePath = registroParaActualizar.ImagePath;
                nuevoProducto.Estado = registroParaActualizar.Estado;
                nuevoProducto.Stock = registroParaActualizar.Stock;

                db.SaveChanges();
                return Mapper.Map<ProductoRegistrado>(nuevoProducto);
            }
        }

        public void Borrar(int IdDelRegistro)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                Producto nuevaLinea = new Producto() { Id = IdDelRegistro };
                db.Producto.Attach(nuevaLinea);
                db.Producto.Remove(nuevaLinea);
                db.SaveChanges();

            }
        }

        public int Count()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Database.ExecuteSqlCommand("select COUNT(Id) from Producto");

            }
        }

        public List<ProductoRegistrado> Filtrar(ProductoRegistrado registroGuardos)
        {
            throw new NotImplementedException();
        }

        public ProductoActualizar FindById(int Id)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return Mapper.Map<ProductoActualizar>(db.Producto.Find(Id));
            }
        }

        public List<ProductoRegistrado> Listar()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Producto.ToList().Select(x => Mapper.Map<ProductoRegistrado>(x)).ToList();
            }
        }

        public IEnumerable<ProductoRegistrado> PagedList(int startRow, int endRow)
        {
            IEnumerable<ProductoRegistrado> list;

            if (startRow >= endRow) return new List<ProductoRegistrado>();
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                SqlParameter startRowParam = new SqlParameter("@startRow", startRow);
                SqlParameter endRowParam = new SqlParameter("@endRow", @endRow);
                list = db.Database.SqlQuery<ProductoRegistrado>("ProductoPagedList @startRow,@endRow", startRowParam, endRowParam).ToList();

                return list;
            }
        }

        public ProductoRegistrado Registrar(ProductoNuevo registroNuevo)
        {
            Producto nuevoProducto = Mapper.Map<Producto>(registroNuevo);
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                db.Producto.Add(nuevoProducto);
                db.SaveChanges();
            }
            return Mapper.Map<ProductoRegistrado>(nuevoProducto);
        }
    }
}

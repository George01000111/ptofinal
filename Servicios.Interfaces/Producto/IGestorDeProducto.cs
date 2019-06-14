using Servicios.Interfaces.Compartido;
using Servicios.Interfaces.Producto.Peticiones;
using Servicios.Interfaces.Producto.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Producto
{
    public interface IGestorDeProducto : IMantenimientoBase<ProductoNuevo, ProductoActualizar, ProductoRegistrado>
    {
        IEnumerable<ProductoRegistrado> PagedList(int startRow, int endRow);
        int Count();
        ProductoActualizar FindById(int Id);


    }
}

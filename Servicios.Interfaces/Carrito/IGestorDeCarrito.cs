using Servicios.Interfaces.Carrito.Peticiones;
using Servicios.Interfaces.Carrito.Respuestas;
using Servicios.Interfaces.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Carrito
{
    public interface IGestorDeCarrito : IMantenimientoBase<CarritoNuevo, CarritoActualizar, CarritoRegistrado>
    {
        CarritoActualizar FindById(int Id);
        int Count();
        IEnumerable<CarritoRegistrado> PagedList(int startRow, int endRow, string nombre);

        List<CarritoRegistrado> ListarXNomb(string Nombre);

    }
}

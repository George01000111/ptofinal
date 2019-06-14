using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Compartido
{
    public interface IMantenimientoBase<TRegistroNuevo, TRegistroParaActualizar, TRegistroGuardado>
    {
        TRegistroGuardado Registrar(TRegistroNuevo registroNuevo);
        List<TRegistroGuardado> Listar();
        TRegistroGuardado Actualizar(TRegistroParaActualizar registroParaActualizar);
        void Borrar(int IdDelRegistro);

        List<TRegistroGuardado> Filtrar(TRegistroGuardado registroGuardos);
    }
}

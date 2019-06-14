using Servicios.Interfaces.Compartido;
using Servicios.Interfaces.Rol.Peticiones;
using Servicios.Interfaces.Rol.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Rol
{
    public interface IGestorDeRol : IMantenimientoBase<RolNuevo, RolActualizar, RolRegistrado>
    {
    
    }
}

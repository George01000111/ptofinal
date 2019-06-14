using Servicios.Interfaces.Compartido;
using Servicios.Interfaces.Usuario.Peticiones;
using Servicios.Interfaces.Usuario.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces.Usuario
{
    public interface IGestorDeUsuario : IMantenimientoBase<UsuarioNuevo, UsuarioActualizar, UsuarioRegistrado>
    {

        UsuarioRegistradoOk FindById2(int Id);

        UsuarioActualizar FindById(int Id);
        List<UsuarioRegistradoOk> ListarOk();

        IEnumerable<UsuarioRegistradoOk> PagedList(int startRow, int endRow);

        int Count();

        List<UsuarioRegistrado> Login(string nombreusuario,string contraseña);


    }
}

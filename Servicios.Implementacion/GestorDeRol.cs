using AutoMapper;
using Dominio.Contextos;
using Servicios.Interfaces.Rol;
using Servicios.Interfaces.Rol.Peticiones;
using Servicios.Interfaces.Rol.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementacion
{
    public class GestorDeRol : IGestorDeRol
    {
        public RolRegistrado Actualizar(RolActualizar registroParaActualizar)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int IdDelRegistro)
        {
            throw new NotImplementedException();
        }

        public List<RolRegistrado> Filtrar(RolRegistrado registroGuardos)
        {
            throw new NotImplementedException();
        }

        public List<RolRegistrado> Listar()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Rol.ToList().Select(x => Mapper.Map<RolRegistrado>(x)).ToList();
            }
        }

        public RolRegistrado Registrar(RolNuevo registroNuevo)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Dominio.Contextos;
using Dominio.Entidades.Tienda;
using Servicios.Interfaces.Usuario;
using Servicios.Interfaces.Usuario.Peticiones;
using Servicios.Interfaces.Usuario.Respuesta;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementacion
{
    public class GestorDeUsuario : IGestorDeUsuario
    {
        public UsuarioRegistrado Actualizar(UsuarioActualizar registroParaActualizar)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {

                Usuario nuevoUsuario = db.Usuarios.Find(registroParaActualizar.Id);
                nuevoUsuario.NombreUsuario = registroParaActualizar.NombreUsuario;
                nuevoUsuario.Apellidos = registroParaActualizar.Apellidos;
                nuevoUsuario.Nombres = registroParaActualizar.Nombres;
                nuevoUsuario.FechaNacimiento = registroParaActualizar.FechaNacimiento;
                nuevoUsuario.Telefono = registroParaActualizar.Telefono;
                nuevoUsuario.EstadoCivil = registroParaActualizar.EstadoCivil;
                nuevoUsuario.RolId = registroParaActualizar.RolId;
                nuevoUsuario.Estado= registroParaActualizar.Estado;
                nuevoUsuario.Contraseña= registroParaActualizar.Contraseña;

                db.SaveChanges();

                return Mapper.Map<UsuarioRegistrado>(nuevoUsuario);
            }
        }

        public void Borrar(int IdDelRegistro)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                Usuario nuevaLinea = new Usuario() { Id = IdDelRegistro };
                db.Usuarios.Attach(nuevaLinea);
                db.Usuarios.Remove(nuevaLinea);
                db.SaveChanges();

            }
        }

        public int Count()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
              return db.Database.ExecuteSqlCommand("select COUNT(Id) from Usuario");
              
            }
        }

        public List<UsuarioRegistrado> Filtrar(UsuarioRegistrado registroGuardos)
        {
            throw new NotImplementedException();
        }

        public UsuarioActualizar FindById(int Id)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {

                return Mapper.Map<UsuarioActualizar>(db.Usuarios.Find(Id));
            }
        }

        public UsuarioRegistradoOk FindById2(int Id)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {

                var result = (from U in db.Usuarios
                              join R in db.Rol on U.RolId equals R.Id
                              where (U.Id== Id)
                              select new
                              {
                                  Id = U.Id,
                                  NombreUsuario = U.NombreUsuario,
                                  Apellidos = U.Apellidos,
                                  Nombres = U.Nombres,
                                  FechaNacimiento = U.FechaNacimiento,
                                  Telefono = U.Telefono,
                                  Estado = U.Estado,
                                  EstadoCivil = U.EstadoCivil,

                                  descripcion = R.descripcion,


                              }).ToList();

          
                 UsuarioRegistradoOk UsuarioRegOk = new UsuarioRegistradoOk();
                   
                result.ForEach(dto => {
                  UsuarioRegOk.Id = dto.Id;
                    UsuarioRegOk.NombreUsuario = dto.NombreUsuario;
                    UsuarioRegOk.Apellidos = dto.Apellidos;
                    UsuarioRegOk.Nombres = dto.Nombres;
                    UsuarioRegOk.FechaNacimiento = dto.FechaNacimiento;
                    UsuarioRegOk.Telefono = dto.Telefono;
                    UsuarioRegOk.EstadoCivil = dto.EstadoCivil;
                    UsuarioRegOk.Estado = dto.Estado;
                    UsuarioRegOk.Rol = dto.descripcion;
                });

                return UsuarioRegOk;
            }
        }

        public List<UsuarioRegistrado> Listar()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                return db.Usuarios.ToList().Select(x => Mapper.Map<UsuarioRegistrado>(x)).ToList();
            }
        }

        public List<UsuarioRegistradoOk> ListarOk()
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {

                var result = (from U in db.Usuarios
                              join R in db.Rol on U.RolId equals R.Id
                           
                              select new
                              {
                                  Id = U.Id,
                                  NombreUsuario = U.NombreUsuario,
                                  Apellidos = U.Apellidos,
                                  Nombres = U.Nombres,
                                  FechaNacimiento = U.FechaNacimiento,
                                  Telefono = U.Telefono,
                                  Estado = U.Estado,
                                  EstadoCivil = U.EstadoCivil,
                                  Contraseña = U.Contraseña,
                                  descripcion = R.descripcion,
                                 

                              }).ToList();

                List<UsuarioRegistradoOk> ListUsuarioOk = new List<UsuarioRegistradoOk>();


                result.ForEach(dto => {
                    UsuarioRegistradoOk UsuarioRegOk = new UsuarioRegistradoOk();
                    UsuarioRegOk.Id = dto.Id;
                    UsuarioRegOk.NombreUsuario = dto.NombreUsuario;
                    UsuarioRegOk.Apellidos = dto.Apellidos;
                    UsuarioRegOk.Nombres = dto.Nombres;
                    UsuarioRegOk.FechaNacimiento = dto.FechaNacimiento;
                    UsuarioRegOk.Telefono = dto.Telefono;
                    UsuarioRegOk.EstadoCivil = dto.EstadoCivil;
                    UsuarioRegOk.Estado = dto.Estado;
                    UsuarioRegOk.Rol = dto.descripcion;
                    UsuarioRegOk.Contraseña = dto.Contraseña;
                    ListUsuarioOk.Add(UsuarioRegOk);
                });

                return ListUsuarioOk;
            }
        }

        public List<UsuarioRegistrado> Login(string nombreusuario, string contraseña)
        {
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
              

                return db.Usuarios.Where(x => (x.NombreUsuario.Contains(nombreusuario) && x.Contraseña.Contains(contraseña) ))
                           .ToList()
                           .Select(x => Mapper.Map<UsuarioRegistrado>(x))
                           .ToList();

            }
        }

        public IEnumerable<UsuarioRegistradoOk> PagedList(int startRow, int endRow)
        {
            IEnumerable<UsuarioRegistradoOk> list;

            if (startRow >= endRow) return new List<UsuarioRegistradoOk>();
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                SqlParameter startRowParam = new SqlParameter("@startRow", startRow);
                SqlParameter endRowParam = new SqlParameter("@endRow", @endRow);
                list = db.Database.SqlQuery<UsuarioRegistradoOk>("UsuariosPagedList @startRow,@endRow", startRowParam, endRowParam).ToList();

                return list;
            }
        }

        public UsuarioRegistrado Registrar(UsuarioNuevo registroNuevo)
        {
            Usuario nuevoUsuario = Mapper.Map<Usuario>(registroNuevo);
            using (TrabajoFinalBD db = new TrabajoFinalBD())
            {
                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();
            }
            return Mapper.Map<UsuarioRegistrado>(nuevoUsuario);
        }
    }
}

﻿using Servicios.Implementacion;
using Servicios.Interfaces.Rol;
using Servicios.Interfaces.Rol.Respuesta;
using Servicios.Interfaces.Usuario;
using Servicios.Interfaces.Usuario.Peticiones;
using Servicios.Interfaces.Usuario.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Mvc.Authorization;
using TrabajoFinal.Mvc.Constantes;
using TrabajoFinal.Mvc.Helper;

namespace TrabajoFinal.Mvc.Controllers
{

    [UserLoggedOn]
    [AdminsOnly]
    //[ErrorActionFilter]
    [RoutePrefix("Usuario")]
    public class UsuarioController : Controller
    {
        IGestorDeUsuario _gestorDeUsuarios = new GestorDeUsuario();
        IGestorDeRol _gestorDeRol = new GestorDeRol();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(_gestorDeUsuarios.ListarOk());
        }


        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<UsuarioRegistradoOk>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _gestorDeUsuarios.PagedList(startRecord, endRecord));
        }


        [HttpPost]
        public UsuarioRegistrado Registrar(UsuarioNuevo registroNuevo)
        {
            return this._gestorDeUsuarios.Registrar(registroNuevo);
        }


        public PartialViewResult Create()
        {
              if (!ModelState.IsValid) return PartialView("_Create");

            HomeHelper Homehelper = new HomeHelper();
            var listCompanies = Homehelper.GetCompanies();
            //List<RolRegistrado> listaRol = new List<RolRegistrado>();
            ViewBag.listCompanies = listCompanies;
            //return View();

            //return View();

            return PartialView("_Create");

        }

        [HttpPost]
        public ActionResult Create(UsuarioNuevo registroNuevo)
        {
            //this._gestorDeRol.Listar();

            if (!ModelState.IsValid) return PartialView("_Create", registroNuevo);
            this._gestorDeUsuarios.Registrar(registroNuevo);
            return PartialView("_List", _gestorDeUsuarios.ListarOk());
        }

        public ActionResult Details(int id)
        {
            return View(_gestorDeUsuarios.FindById(id));
        }


        public PartialViewResult Edit(int id)
        {
            HomeHelper Homehelper = new HomeHelper();
            var listCompanies = Homehelper.GetCompanies();
            //List<RolRegistrado> listaRol = new List<RolRegistrado>();
            ViewBag.listCompanies = listCompanies;
            UsuarioActualizar ssss = new UsuarioActualizar();
            ssss = _gestorDeUsuarios.FindById(id);
            return PartialView("_Edit", ssss);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioActualizar usuarioActualizar)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", usuarioActualizar);
            _gestorDeUsuarios.Actualizar(usuarioActualizar);
            return PartialView("_List", _gestorDeUsuarios.ListarOk());
        }

        public ActionResult Delete(int id)
        {
            var usuario =  _gestorDeUsuarios.FindById2(id);
            return PartialView("_Delete", usuario);
        }

        [HttpPost]
        public ActionResult Delete(UsuarioRegistradoOk UserOk)
        {
            _gestorDeUsuarios.Borrar(Convert.ToInt32(UserOk.Id));
             return PartialView("_List", _gestorDeUsuarios.ListarOk());
        }



        [HttpGet]
        [Route("Count/{rows:int}")]
        //[Route("{rows:int}")]
        //[Route("Count")]
        public int Count(int rows)
        {
            //int rows = 1;
            var totalRecords = _gestorDeUsuarios.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }

        [AllowAnonymous]
        public ActionResult Iniciar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iniciar(UsuarioNuevo registroNuevo)
        {

            List<UsuarioRegistrado> reg = new List<UsuarioRegistrado>() ;
            reg = _gestorDeUsuarios.Login(registroNuevo.NombreUsuario, registroNuevo.Contraseña);

            UsuarioNuevo un = new UsuarioNuevo();
            un.Id= reg[0].Id;
            un.NombreUsuario = reg[0].NombreUsuario;
            un.Apellidos= reg[0].Apellidos;
            un.Nombres = reg[0].Nombres;
            un.FechaNacimiento = reg[0].FechaNacimiento;
            un.Telefono = reg[0].Telefono;
            un.EstadoCivil = reg[0].EstadoCivil;
            un.Estado = reg[0].Estado;
            un.RolId= reg[0].RolId;
            un.Contraseña= reg[0].Contraseña;


            if (reg.Count>0)
                {

                Session[SessionName.User] = un;

                if (reg[0].RolId==3)
                    {
                    return RedirectToAction("Index_Administrador", "Home");
                }
                else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "contraseña invalido";
                }
            //}
            return PartialView("_Create");
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }




    }
}
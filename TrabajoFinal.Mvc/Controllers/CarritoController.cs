using Servicios.Implementacion;
using Servicios.Interfaces.Carrito;
using Servicios.Interfaces.Carrito.Peticiones;
using Servicios.Interfaces.Carrito.Respuestas;
using Servicios.Interfaces.Usuario.Peticiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Mvc.Authorization;
using TrabajoFinal.Mvc.Constantes;

namespace TrabajoFinal.Mvc.Controllers
{

    [UserLoggedOn]
    [RoutePrefix("Carrito")]
    public class CarritoController : Controller
    {


        IGestorDeCarrito _gestorDeCarrito = new GestorDeCarrito();

        // GET: Carrito
        public ActionResult Index()
        {
            List<CarritoRegistrado> n = new List<CarritoRegistrado>();
            n = _gestorDeCarrito.Listar();

            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];
            ViewBag.Nombre = objUser.NombreUsuario;

            return View(_gestorDeCarrito.Listar());
        }

        public PartialViewResult Create()
        {
            if (!ModelState.IsValid) return PartialView("_Create");

            return PartialView("_Create");

        }

        [HttpPost]
        public ActionResult Create(CarritoNuevo registroNuevo)
        {

            if (!ModelState.IsValid) return PartialView("_Create", registroNuevo);
            this._gestorDeCarrito.Registrar(registroNuevo);
            return PartialView("_List", _gestorDeCarrito.Listar());
        }


        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {

            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];

            if (page <= 0 || rows <= 0) return PartialView(new List<CarritoRegistrado>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _gestorDeCarrito.PagedList(startRecord, endRecord, objUser.NombreUsuario));
        }

        [HttpGet]
        [Route("Count/{rows:int}")]
        //[Route("{rows:int}")]
        //[Route("Count")]
        public int Count(int rows)
        {
            //int rows = 1;
            var totalRecords = _gestorDeCarrito.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }




        public PartialViewResult Edit(int id)
        {

            CarritoActualizar ssss = new CarritoActualizar();

            ssss = _gestorDeCarrito.FindById(id);
            return PartialView("_Edit", ssss);
        }

        [HttpPost]
        public ActionResult Edit(CarritoActualizar productoActualizar)
        {

            if (!ModelState.IsValid) return PartialView("_Edit", productoActualizar);

            _gestorDeCarrito.Actualizar(productoActualizar);
            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];
            return PartialView("_List", _gestorDeCarrito.ListarXNomb(objUser.NombreUsuario));
        }

        public ActionResult Delete(int id)
        {
            var usuario = _gestorDeCarrito.FindById(id);
            return PartialView("_Delete", usuario);
        }

        [HttpPost]
        public ActionResult Delete(CarritoRegistrado UserOk)
        {
            _gestorDeCarrito.Borrar(Convert.ToInt32(UserOk.Id));

            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];
            return PartialView("_List", _gestorDeCarrito.ListarXNomb(objUser.NombreUsuario));

        }


    }
}
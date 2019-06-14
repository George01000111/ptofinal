using Dominio.Entidades.Tienda;
using Servicios.Implementacion;
using Servicios.Interfaces.Carrito;
using Servicios.Interfaces.Carrito.Peticiones;
using Servicios.Interfaces.Producto;
using Servicios.Interfaces.Producto.Peticiones;
using Servicios.Interfaces.Producto.Respuestas;
using Servicios.Interfaces.Usuario.Peticiones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal.Mvc.Authorization;
using TrabajoFinal.Mvc.Constantes;

namespace TrabajoFinal.Mvc.Controllers
{
    [UserLoggedOn]
    [RoutePrefix("ProductosPedidos")]
    public class ProductosPedidosController : Controller
    {
        IGestorDeProducto _gestorDeProducto = new GestorDeProducto();
        IGestorDeCarrito _gestorDeCarrito= new GestorDeCarrito();
    


        // GET: ProductosPedidos
        public ActionResult Index()
        {
            List<ProductoRegistrado> n = new List<ProductoRegistrado>();
            n = _gestorDeProducto.Listar();

            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];
            ViewBag.Nombre = objUser.NombreUsuario;
            return View(_gestorDeProducto.Listar());
        }

        public PartialViewResult Create()
        {
            if (!ModelState.IsValid) return PartialView("_Create");

            return PartialView("_Create");

        }

        [HttpPost]
        public ActionResult Create(ProductoNuevo registroNuevo)
        {

            string FileName = Path.GetFileNameWithoutExtension(registroNuevo.ImageFile.FileName);
            string FileExtension = Path.GetExtension(registroNuevo.ImageFile.FileName);

            registroNuevo.ImagePath = FileName + FileExtension;

            if (!ModelState.IsValid) return PartialView("_Create", registroNuevo);

            this._gestorDeProducto.Registrar(registroNuevo);
            return PartialView("_Detalle", _gestorDeProducto.Listar());
        }



        [Route("Orden/{page:int}/{rows:int}")]
        public PartialViewResult Orden(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<ProductoRegistrado>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_Orden", _gestorDeProducto.PagedList(startRecord, endRecord));
        }

        [HttpGet]
        [Route("Count/{rows:int}")]
        //[Route("{rows:int}")]
        //[Route("Count")]
        public int Count(int rows)
        {
            //int rows = 1;
            var totalRecords = _gestorDeProducto.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }


        public ActionResult AgregarPedido(int id)
        {
            var usuario = _gestorDeProducto.FindById(id);
            return PartialView("_Delete", usuario);
        }
        [HttpPost]
        public ActionResult AgregarPedido(ProductoRegistrado UserOk)
        {
            //_gestorDeUsuarios.Borrar(Convert.ToInt32(UserOk.Id));
            return View(_gestorDeProducto.Listar());
        }



        public ActionResult detalle(int id)
        {
            var usuario = _gestorDeProducto.FindById(id);
            return PartialView("_detalle", usuario);
        }

        [HttpPost]
        public ActionResult detalle(ProductoRegistrado prodReg)
        {

            UsuarioNuevo objUser = (UsuarioNuevo)Session[SessionName.User];

            ProductoActualizar x = new ProductoActualizar();

            x = _gestorDeProducto.FindById(prodReg.Id);

            CarritoNuevo carrito =new CarritoNuevo();
            carrito.NombreProd = x.Descripcion;
            carrito.Precio = x.Precio;
            carrito.Cantidad = 1;
            carrito.NombreUsuario= objUser.NombreUsuario;
            _gestorDeCarrito.Registrar(carrito);

            //_gestorDeProducto.Borrar(Convert.ToInt32(UserOk.Id));
            return PartialView("_Orden", _gestorDeProducto.Listar());

            

        }




  

    }
}
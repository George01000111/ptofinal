using Servicios.Implementacion;
using Servicios.Interfaces.Producto;
using Servicios.Interfaces.Producto.Peticiones;
using Servicios.Interfaces.Producto.Respuestas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TrabajoFinal.Mvc.Authorization;

namespace TrabajoFinal.Mvc.Controllers
{
    //[UserLoggedOn]
    [RoutePrefix("Producto")]
    public class ProductoController : Controller
    {
        IGestorDeProducto _gestorDeProducto = new GestorDeProducto();
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Producto
        public ActionResult Index()
        {
            _log.Info("Ejecucion de controlador Producto OK");

            List<ProductoRegistrado> n = new List<ProductoRegistrado>();
            n = _gestorDeProducto.Listar();

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

            _log.Info("Ejecucion de controlador create Producto");

            string FileName = Path.GetFileNameWithoutExtension(registroNuevo.ImageFile.FileName);
            string FileExtension = Path.GetExtension(registroNuevo.ImageFile.FileName);

            registroNuevo.ImagePath = FileName + FileExtension;

            if (!ModelState.IsValid) return PartialView("_Create", registroNuevo);

            this._gestorDeProducto.Registrar(registroNuevo);
            return PartialView("_List", _gestorDeProducto.Listar());
        }


        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<ProductoRegistrado>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _gestorDeProducto.PagedList(startRecord, endRecord));
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



        public PartialViewResult Edit(int id)
        {
            ProductoActualizar ssss = new ProductoActualizar();
            ssss = _gestorDeProducto.FindById(id);
            return PartialView("_Edit", ssss);
        }

        [HttpPost]
        public ActionResult Edit(ProductoActualizar productoActualizar)
        {
            _log.Info("Ejecucion de controlador Edit Producto");
            string FileName = Path.GetFileNameWithoutExtension(productoActualizar.ImageFile.FileName);
            string FileExtension = Path.GetExtension(productoActualizar.ImageFile.FileName);

            productoActualizar.ImagePath = FileName + FileExtension;

            if (!ModelState.IsValid) return PartialView("_Edit", productoActualizar);
            _gestorDeProducto.Actualizar(productoActualizar);
            return PartialView("_List", _gestorDeProducto.Listar());
        }

        public ActionResult Delete(int id)
        {
            var usuario = _gestorDeProducto.FindById(id);
            return PartialView("_Delete", usuario);
        }

        [HttpPost]
        public ActionResult Delete(ProductoRegistrado UserOk)
        {
            _log.Info("Ejecucion de controlador delete Producto");
            _gestorDeProducto.Borrar(Convert.ToInt32(UserOk.Id));
            return PartialView("_List", _gestorDeProducto.Listar());
        }
    }




}
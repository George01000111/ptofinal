﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servicios.Interfaces.Producto.Peticiones
{
   public class ProductoActualizar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre del Producto")]
        [Compare("Descripcion", ErrorMessage = "El Nombre y Descripcion no son iguales")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el precio")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Ingrese Descripcion del Producto")]
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        public bool Estado { get; set; }

        public int Stock { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


    }
}

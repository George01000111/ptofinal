using Dominio.Contextos;
using Servicios.Implementacion;
using Servicios.Interfaces.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabajoFinal.Mvc.Helper
{
    public class HomeHelper
    {
        IGestorDeRol _gestorDeRol = new GestorDeRol();
        public IEnumerable<SelectListItem> GetCompanies()
        { 
                return _gestorDeRol.Listar().Select(x => new SelectListItem
                {
                    Text = x.descripcion,
                    Value = x.Id.ToString()
                }).ToList();
        }


        public IEnumerable<SelectListItem> GetEstado()
        {
            return _gestorDeRol.Listar().Select(x => new SelectListItem
            {
                Text = x.descripcion,
                Value = x.Id.ToString()
            }).ToList();
        }


    
       //public IEnumerable estado
       // {
       //     Nota_Pedido = 6,
       //     Factura = 1,
       //     Boleta = 3
       // }



    }
}


using System;
using System.Linq;
using Dominio.Contextos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dominio.PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreacionDeBaseDeDatos()
        {
            new TrabajoFinalBD().Producto.ToList();



        }
    }
}

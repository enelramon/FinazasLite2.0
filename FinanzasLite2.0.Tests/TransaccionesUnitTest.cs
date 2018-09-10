using System;
using Entities;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinanzasLite2._0.Tests
{
    [TestClass]
    public class TransaccionesUnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            TransaccionBLL rep = new TransaccionBLL();
            Assert.IsTrue(rep.Guardar(GetTransaccion()));
        }

        [TestMethod]
        public void Modificar()
        {
            TransaccionBLL rep = new TransaccionBLL();
            Assert.IsTrue(rep.Modificar(GetTransaccion()));
        }

        [TestMethod]
        public void Eliminar()
        {
            TransaccionBLL rep = new TransaccionBLL();
            Assert.IsTrue(rep.Eliminar(2));
        }

        private Transacciones GetTransaccion()
        {
            Transacciones transaccion = new Transacciones();
            transaccion.TransaccionId = 2;
            transaccion.CuentaId = 1;
            transaccion.CategoriaId = 1;
            transaccion.Fecha = DateTime.Now;
            transaccion.Descripcion = "Descripcion";
            transaccion.Tipo = TiposTransacciones.Entrada;
            transaccion.Monto = 300;
            transaccion.DestinoId = 1;

            return transaccion;
        }
    }
}

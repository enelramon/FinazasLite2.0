using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinanzasLite2._0.Tests
{
    [TestClass]
    public class TransaccionesUnitTest
    {
        [TestMethod]
        public void GuardarTransaccion()
        {
            BLL.RepositorioTransaccion repositorio =
                   new BLL.RepositorioTransaccion();

            Assert.IsTrue(repositorio.Guardar(GetTransacciones()));
        }

        private Transacciones GetTransacciones()
        {
            Transacciones transacciones = new Transacciones();
            transacciones.TransaccionId = 0;
            transacciones.DestinoId = 1;
            transacciones.CuentaId = 1;
            transacciones.CategoriaId = 1;
            transacciones.Descripcion = "Prueba";
            transacciones.Fecha = DateTime.Now;
            transacciones.Monto = 100;
            transacciones.Tipo = (int)TiposTransacciones.Entrada;

            return transacciones;
        }

        [TestMethod]
        public void EliminarTransaccion()
        {
            BLL.RepositorioTransaccion repositorio =
                   new BLL.RepositorioTransaccion();

            Assert.IsTrue(repositorio.Eliminar(4));
        }

        [TestMethod]
        public void ModificarTransaccion()
        {
            BLL.RepositorioTransaccion repositorio =
                   new BLL.RepositorioTransaccion();

            Assert.IsTrue(repositorio.Modificar(GetTransaccionesModificar()));
        }

        private Transacciones GetTransaccionesModificar()
        {
            Transacciones transacciones = new Transacciones();
            transacciones.TransaccionId = 3;
            transacciones.DestinoId = 1;
            transacciones.CuentaId = 1;
            transacciones.CategoriaId = 1;
            transacciones.Descripcion = "Prueba";
            transacciones.Fecha = DateTime.Now;
            transacciones.Monto = 400;
            transacciones.Tipo = (int)TiposTransacciones.Entrada;

            return transacciones;
        }
    }
}

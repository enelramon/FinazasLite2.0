using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinanzasLite2._0.Tests
{
    [TestClass]
    public class CuentasUnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            BLL.RepositorioBase<Cuentas> repositorio =
                new BLL.RepositorioBase<Cuentas>();

            Assert.IsTrue(repositorio.Guardar(GetCuenta()));
        }

        private Cuentas GetCuenta()
        {
            return new Cuentas()
            {
                CuentaId = 1,
                Descripcion = "Banco Popular",
                Origen = Origenes.Deudor
            };
        }
    }
}

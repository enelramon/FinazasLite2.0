using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinanzasLite2._0.Tests
{
    [TestClass]
    public class TransaccionesUnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            BLL.RepositorioBase<Transacciones> repositorio =
                new BLL.RepositorioBase<Transacciones>();

            //todo: Cuando se guarde la transaccion debe descontar 
            //el presupuesto de la categoria. Guardar, Modificar, Eliminar

            Assert.IsTrue(repositorio.Guardar(GetTransaccion()));
        }

        private Transacciones GetTransaccion()
        {
            return new Transacciones()
            {
                TransaccionId = 0,
                CuentaId = 1,
                CategoriaId = 1,
                Fecha = DateTime.Now,
                Descripcion = "gastos",
                Tipo = (int)TiposTransacciones.Salida,
                Monto = 100,
                DestinoId = 0
            };
        }
    }
}

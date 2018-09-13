using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
    [TestClass()]
    public class PresupuestosRepositorioTests
    {
       [TestMethod]
        public void GuardarPresupuesto()
        {
            BLL.PresupuestosRepositorio repositorio = new BLL.PresupuestosRepositorio();
            var paso = repositorio.Guardar(GetPresupuesto());
            Assert.IsTrue(paso);
        }

        private Presupuestos GetPresupuesto()
        {
            Presupuestos presupuestos = new Presupuestos();
            presupuestos.Descripcion = "Prueba";
            presupuestos.PresupuestoId = 0;
            presupuestos.AgregarDetalle(0, 0, 4, 500);
            return presupuestos;
        }

        [TestMethod]
        public void GuardarEgreso()
        {
            BLL.RepositorioBase<TiposEgresos> repositorio = new BLL.RepositorioBase<TiposEgresos>();
            var paso = repositorio.Guardar(GetTiposEgresos());
            Assert.IsTrue(paso);
        }

        private TiposEgresos GetTiposEgresos()
        {
            TiposEgresos egreso = new TiposEgresos();
            egreso.Acumulado = 0;
            egreso.Descripcion = "Prueba";
            egreso.EsActivo = true;
            egreso.TipoEgresoId = 0;
            return egreso;

        }

        [TestMethod]
        public void EliminarPresupuesto()
        {
            BLL.RepositorioBase<TiposEgresos> repositorio = new BLL.RepositorioBase<TiposEgresos>();
            var paso = repositorio.Eliminar(4);
            Assert.IsTrue(paso);
        }

    }
}
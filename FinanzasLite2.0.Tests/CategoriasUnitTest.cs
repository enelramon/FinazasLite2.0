using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinanzasLite2._0.Tests
{
    [TestClass]
    public class CategoriasUnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();
            Categorias categoria = new Categorias();

            //todo: validaciones adicionales
            LlenaClase(categoria);

            Assert.IsTrue(repositorio.Guardar(categoria));
        }

        private void LlenaClase(Categorias categoria)
        {
            categoria.CategoriaId = 1;
            categoria.Descripcion = "Comida";
            categoria.Presupuesto = 1000;
            categoria.Tipo = TiposTransacciones.Salida;

        }
    }
}

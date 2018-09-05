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
            BLL.RepositorioBase<Categorias> repositorio = 
                new BLL.RepositorioBase<Categorias>();
        
            Assert.IsTrue(repositorio.Guardar(GetCategoria()));
        }

        private Categorias GetCategoria()
        {
            Categorias categoria = new Categorias();

            categoria.CategoriaId = 1;
            categoria.Descripcion = "Comida";
            categoria.Presupuesto = 1000;
            categoria.Tipo = TiposTransacciones.Salida;

            return categoria;
        }
    }
}

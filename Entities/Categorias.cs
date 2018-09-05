using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Presupuesto { get; set; }
        public TiposTransacciones Tipo { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
            Presupuesto = 0;
            Tipo = TiposTransacciones.Entrada;
        }

        public Categorias(int categoriaId, string descripcion, decimal presupuesto, TiposTransacciones tipo)
        {
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Presupuesto = presupuesto;
            Tipo = tipo;
        }
    }
}

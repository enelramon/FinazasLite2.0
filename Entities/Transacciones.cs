using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Transacciones
    {
        [Key]
        public int TransaccionId { get; set; }
        public int CuentaId { get; set; }
        public int CategoriaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TiposTransacciones Tipo { get; set; }
        public decimal Monto { get; set; }
        public int DestinoId { get; set; }

        public Transacciones()
        {
            TransaccionId = 0;
            CuentaId = 0;
            CategoriaId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            Tipo = TiposTransacciones.Entrada;
            Monto = 0;
            DestinoId = 0;
        }
    } 
}

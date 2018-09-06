using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cuentas
    {
        [Key]
        public int CuentaId { get; set; }
        public string Descripcion { get; set; }
        public Origenes Origen { get; set; }

        public Cuentas(int cuentaId, string descripcion, Origenes origen)
        {
            CuentaId = cuentaId;
            Descripcion = descripcion;
            Origen = origen;
        }

        public Cuentas()
        {
            CuentaId = 0;
            Descripcion = string.Empty;
            Origen = 0;
        }
    }
}

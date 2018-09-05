using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public enum Origenes
    {
        Deudor,
        Acreedor
    }

    public enum TiposMensaje
    {
        Success,
        Error
    }

    public enum TiposTransacciones
    {
        Entrada,
        Salida,
        Transferencia
    }
}
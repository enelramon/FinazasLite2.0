using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace FinanzasLite.Reportes
{
    public partial class RptViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//solo se carga si no se esta haciendo postback
            {
                //Indicar que es con reporte local
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();//reiniciar el reporte para evitar que este sucio de una llamada anterior

                //Indicar la ruta del reporte en el servidor
                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCategorias.rdlc");

                MyReportViewer.LocalReport.DataSources.Clear(); //Limpiar la fuente datos

                //Agregar una nueva fuente de datos con las categorias que deseamos imprimir
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Categorias", 
                                                                Categorias.ObtenerDatosParaReporte("CategoriaId>17")));

                MyReportViewer.LocalReport.Refresh();//Refrescar el reporte para que muestre los datos
            }
        }
    }
}
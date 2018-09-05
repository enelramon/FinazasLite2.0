using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanzasLite2._0.Consultas
{
    public partial class cCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();

                DatosGridView.DataSource = repositorio.GetList(c => true);
                DatosGridView.DataBind();
            }
        }
    }
}
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanzasLite2._0.Consultas
{
    public partial class cCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Categorias, bool>> filtro = x => true;
            BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();

            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://ID
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.CategoriaId == id;
                    break;
                case 1:// nombre
                    filtro = c => c.Descripcion.Contains(FiltroTextBox.Text);
                    break;
            }
            
            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }
    }
}
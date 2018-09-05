using Entities;
using FinanzasLite2._0.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanzasLite2._0.Registros
{
    public partial class rCategorias : System.Web.UI.Page
    {
        private void LlenaClase(Categorias categoria)
        {
            categoria.CategoriaId = Utils.ToInt(IdTextBox.Text);
            categoria.Descripcion = DescripcionTextBox.Text;
            categoria.Presupuesto = Utils.ToDecimal(PresupuestoTextBox.Text);
            categoria.Tipo = (TiposTransacciones)Enum.Parse(typeof(TiposTransacciones), TipoDropDownList.SelectedValue);

        }

        private void LlenaCampos(Categorias categoria)
        {
            IdTextBox.Text = categoria.CategoriaId.ToString();
            DescripcionTextBox.Text = categoria.Descripcion;
            PresupuestoTextBox.Text = categoria.Presupuesto.ToString("N2");
            TipoDropDownList.SelectedValue = Convert.ToInt16(categoria.Tipo).ToString();

        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            PresupuestoTextBox.Text = "";
            //TipoDropDownList.SelectedValue = "1";
        }

        void LlenarCombos()
        {
            TipoDropDownList.DataSource = Enum.GetValues(typeof(TiposTransacciones));
            TipoDropDownList.DataBind();
        }
        void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombos();

                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                { 
                    BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();
                    var categoria = repositorio.Buscar(id);

                    if (categoria==null)
                    {
                        MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(categoria);
                    }

                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();
            Categorias categoria = new Categorias();
            bool paso = false;

            //todo: validaciones adicionales
            LlenaClase(categoria);         
           
            if (categoria.CategoriaId == 0)
                paso = repositorio.Guardar(categoria);
            else
                paso = repositorio.Modificar(categoria);

            if (paso)
            {
                MostrarMensaje(TiposMensaje.Success, "Transaccion Exitosa!");
                Limpiar();
            }
            else
                MostrarMensaje(TiposMensaje.Error, "No fue posible terminar la transacción");

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();
            int id = Utils.ToInt(IdTextBox.Text);

            var categoria = repositorio.Buscar(id);

            if (categoria==null)
                MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
            else
                repositorio.Eliminar(id);
        }
    }
}
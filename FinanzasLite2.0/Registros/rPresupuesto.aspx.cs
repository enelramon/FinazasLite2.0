using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace FinanzasLite2._0.Registros
{
    public partial class rPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TiposEgresos tipoEgreso = new TiposEgresos();

            if (!Page.IsPostBack)
            {
                RepositorioBase<TiposEgresos> repositorioBase = new RepositorioBase<TiposEgresos>();

                TipoEgresoDropDownList.DataSource = repositorioBase.GetList(t => true);
                TipoEgresoDropDownList.DataValueField = "TipoEgresoId";
                TipoEgresoDropDownList.DataTextField = "Descripcion";
                TipoEgresoDropDownList.DataBind();

                ViewState["Presupuesto"] = new Presupuestos();
            }
        }
        protected void BindGrid()
        {
            DetalleGridView.DataSource = (Presupuestos)ViewState["Presupuesto"];
            DetalleGridView.DataBind();
        }


        public Presupuestos LlenarClase()
        {
            Presupuestos Presupuesto = new Presupuestos();

            Presupuesto = (Presupuestos)ViewState["Presupuesto"];

            Presupuesto.PresupuestoId = Utilitarios.Utils.ToInt(PresupuestoTextBox.Text);
            Presupuesto.Descripcion = DescripcionTextBox.Text;

            return Presupuesto;
        }

        public void LlenarCampos(Presupuestos presupuesto)
        {
            Limpiar();
            PresupuestoTextBox.Text = presupuesto.PresupuestoId.ToString();
            DescripcionTextBox.Text = presupuesto.Descripcion;

            this.BindGrid();
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            PresupuestosRepositorio repositorio = new PresupuestosRepositorio();

            var Presupuesto = repositorio.Buscar(Utilitarios.Utils.ToInt(PresupuestoTextBox.Text));
            if (Presupuesto != null)
            {
                LlenarCampos(Presupuesto);
                Utilitarios.Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                Limpiar();
                Utilitarios.Utils.ShowToastr(this, "No se pudo encontrar el presupuesto especificado", "Error", "error");
            }
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Presupuestos Presupuesto = new Presupuestos();

            Presupuesto = (Presupuestos)ViewState["Presupuesto"];
            Presupuesto.AgregarDetalle(0, Presupuesto.PresupuestoId, TipoEgresoDropDownList.SelectedValue, MontoTextBox.Text);

            ViewState["Presupuesto"] = Presupuesto;

            this.BindGrid();
            MontoTextBox.Text = "";
        }

        protected void Limpiar()
        {
            PresupuestoTextBox.Text = "";
            PresupuestoTextBox.Enabled = true;
            DescripcionTextBox.Text = "";
            MontoTextBox.Text = "";
            ViewState["Presupuesto"] = new Presupuestos();
            this.BindGrid();
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            PresupuestosRepositorio repositorio = new PresupuestosRepositorio();
            //todo: agregar demas validaciones
            Presupuestos presupuesto = LlenarClase();

            if (Utilitarios.Utils.ToInt(PresupuestoTextBox.Text) == 0)
                paso = repositorio.Guardar(presupuesto);

            else
                paso = repositorio.Modificar(presupuesto);

            if (paso)
            {
                Utilitarios.Utils.ShowToastr(this, "Transacción exitosa", "Exito", "success");
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Presupuestos presupuesto = new Presupuestos();
            PresupuestosRepositorio repositorio = new PresupuestosRepositorio();

            if (repositorio.Eliminar(Convert.ToInt32(PresupuestoTextBox.Text))
            {

                Utilitarios.Utils.ShowToastr(this, "Registro eliminado", "Exito", "success");
                Limpiar();
            }
            else
                EliminarRequiredFieldValidator.IsValid = false;
        }

    }
}
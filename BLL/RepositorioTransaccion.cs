using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioTransaccion : RepositorioBase<Transacciones>
    {
        public override bool Guardar(Transacciones entity)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                if (RestarPresupuesto(entity.CategoriaId, entity.Monto) && base.Guardar(entity))
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            _contexto = new Contexto();
            var transaccion = _contexto.Transacciones.Find(id);
            try
            {
                if (SumarPresupuesto(transaccion.CategoriaId, transaccion.Monto) && base.Eliminar(id))
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(Transacciones entity)
        {
            bool paso = false;
            _contexto = new Contexto();
            try
            {
                if (ModificarPresupuesto(_contexto.Transacciones.Find(entity.TransaccionId).Monto, entity.CategoriaId, entity.Monto) && base.Modificar(entity))
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool RestarPresupuesto(int id, decimal monto)
        {
            bool paso = false;
            BLL.RepositorioBase<Categorias> _contexto = new BLL.RepositorioBase<Categorias>();
            Categorias Categoria = _contexto.Buscar(id);
            Categoria.Presupuesto -= monto;

            if (_contexto.Modificar(Categoria))
                paso = true;

            return paso;
        }

        private bool SumarPresupuesto(int id, decimal monto)
        {
            bool paso = false;
            BLL.RepositorioBase<Categorias> _contexto = new BLL.RepositorioBase<Categorias>();
            Categorias Categoria = _contexto.Buscar(id);
            Categoria.Presupuesto += monto;

            if (_contexto.Modificar(Categoria))
                paso = true;

            return paso;
        }

        private bool ModificarPresupuesto(decimal MontoViejaTransaccion, int id, decimal MontoNuevaTransaccion)
        {
            bool paso = false;
            BLL.RepositorioBase<Categorias> _contexto = new BLL.RepositorioBase<Categorias>();
            Categorias Categoria = _contexto.Buscar(id);
            Categoria.Presupuesto += MontoViejaTransaccion;
            Categoria.Presupuesto -= MontoNuevaTransaccion;

            if (_contexto.Modificar(Categoria))
                paso = true;

            return paso;
        }
    }
}

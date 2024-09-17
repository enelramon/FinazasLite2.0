using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestosRepositorio : RepositorioBase<Presupuestos>
    {
        public override bool Guardar(Presupuestos entity)
        {

            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
              
                if (AcumularEgreso(entity.Detalle) && base.Guardar(entity))
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool AcumularEgreso(List<PresupuestosDetalle> Detalle)
        {
            bool paso = false;
            BLL.RepositorioBase<TiposEgresos> contexto = new BLL.RepositorioBase<TiposEgresos>();
            foreach (var item in Detalle)
            {
                var egreso = contexto.Buscar(item.TipoEgresoId);
                egreso.Acumulado += item.Monto;
                contexto.Modificar(egreso);
                paso = true;
            }

            return paso;

        }

        public override Presupuestos Buscar(int id)
        {
            Presupuestos presupuesto = new Presupuestos();
            try
            {
                presupuesto = _contexto.Presupuestos.Find(id);

                presupuesto.Detalle.Count();//Cargar la lista en este punto porque         //luego de hacer Dispose() el Contexto           //no sera posible leer la lista

                foreach (var item in presupuesto.Detalle)//Cargar los nombres de las ciudades            
                { string s = item.TipoEgreso.Descripcion; } //forzando la ciudad a cargarse

            }
            catch (Exception)
            {

                throw;
            }
            return presupuesto;
        }

        public override bool Modificar(Presupuestos presupuesto)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.Presupuestos.Find(presupuesto.PresupuestoId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!presupuesto.Detalle.Exists(d => d.Id == item.Id))
                    {
                        item.TipoEgreso = null;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in presupuesto.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(presupuesto).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
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
            var presupuesto = _contexto.Presupuestos.Find(id);
            presupuesto.Detalle.Count();
            try
            {

                foreach (var item in presupuesto.Detalle)
                {
                    item.TipoEgreso = null;
                }

                if (EliminarAcumulado(presupuesto.Detalle) && base.Eliminar(id))
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool EliminarAcumulado(List<PresupuestosDetalle> Detalle)
        {
            bool paso = false;
            BLL.RepositorioBase<TiposEgresos> contexto = new BLL.RepositorioBase<TiposEgresos>();
            foreach (var item in Detalle)
            {
                var egreso = contexto.Buscar(item.TipoEgresoId);
                egreso.Acumulado -= item.Monto;
                contexto.Modificar(egreso);
                paso = true;
            }

            return paso;
        }


    }
}

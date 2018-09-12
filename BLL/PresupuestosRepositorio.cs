using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestosRepositorio: RepositorioBase<Presupuestos>
    {

        public override Presupuestos Buscar(int id)
        {
            Presupuestos presupuesto = new Presupuestos();
            try
            {
                presupuesto = _contexto.Presupuestos.Find(id);

                presupuesto.Detalle.Count();//Cargar la lista en este punto porque                //luego de hacer Dispose() el Contexto                 //no sera posible leer la lista

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
                //todo: buscar las entidades que no estan para removerlas

                //recorrer el detalle
                foreach (var item in presupuesto.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added; //Muy importante indicar que pasara con la entidad del detalle
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


    }
}

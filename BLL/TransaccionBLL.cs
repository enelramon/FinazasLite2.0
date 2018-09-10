using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data.Entity;

namespace BLL
{
    public class TransaccionBLL : IDisposable, IRepository<Transacciones>
    {
        internal Contexto _contexto;

        public TransaccionBLL()
        {
            _contexto = new Contexto();
        }

        public bool Guardar(Transacciones entity)
        {
            bool paso = false;

            try
            {
                if (_contexto.Set<Transacciones>().Add(entity) != null)
                {
                    DescontarPresupuesto(entity);
                    _contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private void DescontarPresupuesto(Transacciones t)
        {
            var categoria = _contexto.Set<Categorias>().Find(t.CategoriaId);
            if(categoria != null)
            {
                categoria.Presupuesto -= t.Monto;
                _contexto.Entry(categoria).State = EntityState.Modified;
            }
        }

        private void ModificarPresupuesto(Transacciones t)
        {
            var transaccionAnterior = _contexto.Set<Transacciones>().Find(t.TransaccionId);
            var categoria = _contexto.Set<Categorias>().Find(t.CategoriaId);
            _contexto.Entry(transaccionAnterior).State = EntityState.Detached;
            if (transaccionAnterior != null && categoria != null)
            {
                var montoAnt = transaccionAnterior.Monto;
                categoria.Presupuesto += montoAnt;
                categoria.Presupuesto -= t.Monto;
                _contexto.Entry(categoria).State = EntityState.Modified;
            }
            
        }

        private void EliminarTransaccion(Transacciones t)
        {
            var categoria = _contexto.Set<Categorias>().Find(t.CategoriaId);
            if (categoria != null)
            {
                categoria.Presupuesto += t.Monto;
                _contexto.Entry(categoria).State = EntityState.Modified;
            }
        }

        public virtual bool Modificar(Transacciones entity)
        {
            bool paso = false;
            try
            {
                ModificarPresupuesto(entity);
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Transacciones entity = _contexto.Set<Transacciones>().Find(id);
                EliminarTransaccion(entity);
                _contexto.Set<Transacciones>().Remove(entity);
                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            { throw; }
            return paso;
        }

        public Transacciones Buscar(int id)
        {
            Transacciones entity;
            try
            {
                entity = _contexto.Set<Transacciones>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public List<Transacciones> GetList(Expression<Func<Transacciones, bool>> expression)
        {
            List<Transacciones> Lista = new List<Transacciones>();
            try
            {
                Lista = _contexto.Set<Transacciones>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}

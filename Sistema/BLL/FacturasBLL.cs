using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sistema.BLL
{
    public class FacturasBLL
    {
        public static bool Guardar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Facturas.Add(facturas) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            db.Dispose();

            return paso;
        }

        public static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM FacturasDetalle Where FacturaId = {facturas.FacturaId}");
                foreach (var item in facturas.FacturasDetalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Database.ExecuteSqlRaw($"DELETE FROM PagosDetalle Where FacturaId = {facturas.FacturaId}");
                foreach (var item in facturas.PagosDetalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(facturas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = FacturasBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Facturas Buscar(int id)
        {
            Contexto db = new Contexto();
            Facturas facturas = new Facturas();
            try
            {
                facturas = db.Facturas
                    .Include(f => f.FacturasDetalles)
                    .Include(p => p.PagosDetalles)
                    .Where(d => d.FacturaId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return facturas;
        }


        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> facturas)
        {
            Contexto db = new Contexto();
            List<Facturas> Lista = new List<Facturas>();

            try
            {
                Lista = db.Facturas.Where(facturas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}

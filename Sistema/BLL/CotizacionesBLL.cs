using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using Sistema.Entidades;
using Sistema.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sistema.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones cotizaciones)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                cotizaciones.UsuarioId = Sesion.usuarioActual.UsuarioId;
                if (db.Cotizaciones.Add(cotizaciones) != null)
                    paso = db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return paso;
        }
        
        public static bool Modificar(Cotizaciones cotizaciones)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                cotizaciones.UsuarioId = Sesion.usuarioActual.UsuarioId;
                db.Database.ExecuteSqlRaw($"DELETE FROM CotizacionesDetalle Where CotizacionId = {cotizaciones.CotizacionId}");
                foreach(var item in cotizaciones.CotizacionesDetalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(cotizaciones).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }catch(Exception)
            {
                throw;
            }finally
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
                var eliminar = CotizacionesBLL.Buscar(id);
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

        public static Cotizaciones Buscar(int id)
        {
            Contexto db = new Contexto();
            Cotizaciones cotizaciones = new Cotizaciones();
            try
            {
                cotizaciones = db.Cotizaciones
                    .Include(x => x.CotizacionesDetalles)
                    .Where(t => t.CotizacionId == id)
                    .SingleOrDefault();

                    
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return cotizaciones;
        }

        public static List<Cotizaciones> GetList(Expression<Func<Cotizaciones, bool>> cotizaciones)
        {
            Contexto db = new Contexto();
            List<Cotizaciones> Lista = new List<Cotizaciones>();

            try
            {
                Lista = db.Cotizaciones.Where(cotizaciones).ToList();
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}

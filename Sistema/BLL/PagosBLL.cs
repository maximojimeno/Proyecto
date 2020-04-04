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
    public class PagosBLL
    {
        public static bool Guardar(Pagos pagos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                pagos.UsuarioId = Sesion.usuarioActual.UsuarioId;
                if (db.Pagos.Add(pagos) != null)
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

        public static bool Modificar(Pagos pagos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                pagos.UsuarioId = Sesion.usuarioActual.UsuarioId;
                db.Database.ExecuteSqlRaw($"DELETE FROM PagosDetalle Where PagoId = {pagos.PagoId}");
                foreach (var item in pagos.PagosDetalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(pagos).State = EntityState.Modified;
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
                var eliminar = PagosBLL.Buscar(id);
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

        public static Pagos Buscar(int id)
        {
            Contexto db = new Contexto();
            Pagos pagos = new Pagos();
            try
            {
                pagos = db.Pagos
                    .Include(x => x.PagosDetalles)
                    .Where(t => t.PagoId == id)
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
            return pagos;
        }

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> pagos)
        {
            Contexto db = new Contexto();
            List<Pagos> Lista = new List<Pagos>();

            try
            {
                Lista = db.Pagos.Where(pagos).ToList();
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
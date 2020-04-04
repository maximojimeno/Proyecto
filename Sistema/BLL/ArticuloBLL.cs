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
    public class ArticuloBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                articulos.UsuarioId = Sesion.usuarioActual.UsuarioId;
                if (db.Articulos.Add(articulos) != null)
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

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                articulos.UsuarioId = Sesion.usuarioActual.UsuarioId;
                db.Entry(articulos).State = EntityState.Modified;
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
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
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

        public static Articulos Buscar(int id)
        {
            Contexto db = new Contexto();
            Articulos articulos = new Articulos();

            try
            {
                articulos = db.Articulos.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
        {
            List<Articulos> Lista = new List<Articulos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Articulos.Where(articulos).ToList();
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

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
   public  class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.clientes.Add(clientes) != null)
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

        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(clientes).State = EntityState.Modified;
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

        public static Clientes Buscar(int id)
        {
            Contexto db = new Contexto();
            Clientes clientes = new Clientes();

            try
            {
                clientes = db.clientes.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return clientes;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.clientes.Find(id);
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> clientes)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.clientes.Where(clientes).ToList();
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

﻿using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sistema.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Clientes.Add(clientes) != null)
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Clientes.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
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
                clientes = db.Clientes.Find(id);
            }catch(Exception)
            {
                throw;
            }finally
            {
                db.Dispose();
            }
            return clientes;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>>clientes)
        {
            Contexto db = new Contexto();
            List<Clientes> Lista = new List<Clientes>();

            try
            {
                Lista = db.Clientes.Where(clientes).ToList();
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

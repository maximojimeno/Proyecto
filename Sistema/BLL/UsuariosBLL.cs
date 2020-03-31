using System;
using System.Collections.Generic;
using System.Text;
using Sistema.Entidades;
using Sistema.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Sistema.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                usuarios.Password = GetSHA256(usuarios.Password);

                if (db.Usuarios.Add(usuarios) != null)
                {
                    paso = db.SaveChanges() > 0;
                }

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

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            usuarios.Password = GetSHA256(usuarios.Password);
            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return paso;
        }

        public static bool Eliminar(int UsuarioId)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var eliminar = db.Usuarios.Find(UsuarioId);
            db.Entry(eliminar).State = EntityState.Deleted;
            paso = db.SaveChanges() > 0;

            return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Contexto db = new Contexto();
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = db.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuarios)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Usuarios.Where(usuarios).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        private static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
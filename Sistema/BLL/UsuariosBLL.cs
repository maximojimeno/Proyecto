using System;
using System.Collections.Generic;
using System.Text;
using Sistema.Entidades;
using Sistema.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

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

        public static bool modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
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

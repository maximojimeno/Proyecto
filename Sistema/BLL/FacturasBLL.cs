using System;
using System.Collections.Generic;
using System.Text;
using Sistema.Data;
using Sistema.Entidades;

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


    }
}

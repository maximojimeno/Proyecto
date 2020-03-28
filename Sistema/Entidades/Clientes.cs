using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class Clientes
    {
        public Clientes()
        {
            Cotizaciones = new HashSet<Cotizaciones>();
            Facturas = new HashSet<Facturas>();
            Pagos = new HashSet<Pagos>();

            ClienteId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = 0;
            Correo = string.Empty;
            Telefono = 0;
            Direccion = string.Empty;
        }

        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual Usuarios Usuario { get; set; }
        public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }
        public virtual ICollection<Facturas> Facturas { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}

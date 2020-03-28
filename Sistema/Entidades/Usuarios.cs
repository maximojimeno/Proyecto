﻿using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Articulos = new HashSet<Articulos>();
            Clientes = new HashSet<Clientes>();
            Cotizaciones = new HashSet<Cotizaciones>();
            Facturas = new HashSet<Facturas>();
            Pagos = new HashSet<Pagos>();
        }

        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }
        public virtual ICollection<Facturas> Facturas { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}

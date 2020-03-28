using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Rol = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;

            Articulos = new List<Articulos>();
            Clientes = new List<Clientes>();
            Cotizaciones = new List<Cotizaciones>();
            Facturas = new List<Facturas>();
            Pagos = new List<Pagos>();
        }
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual List<Articulos> Articulos { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual List<Clientes> Clientes { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual List<Cotizaciones> Cotizaciones { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual List<Facturas> Facturas { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual List<Pagos> Pagos { get; set; }
    }
}

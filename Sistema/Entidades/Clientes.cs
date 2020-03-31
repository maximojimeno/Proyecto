using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Clientes
    {
        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Balance = 0;
            Correo = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Cotizaciones = new List<Cotizaciones>();
            Facturas = new List<Facturas>();
            Pagos = new List<Pagos>();

        }
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public int Balance { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string? Celular { get; set; }
        public string Direccion { get; set; }

        public virtual Usuarios Usuario { get; set; }

        [ForeignKey("ClienteId")]
        public virtual List<Cotizaciones> Cotizaciones { get; set; }
        [ForeignKey("ClienteId")]
        public virtual List<Facturas> Facturas { get; set; }
        [ForeignKey("ClienteId")]
        public virtual List<Pagos> Pagos { get; set; }

    }
}

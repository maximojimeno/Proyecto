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

        }

        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
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

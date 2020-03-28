using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class Facturas
    {
        public int FacturaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal? Descuento { get; set; }
        public double? ImpuestoTotal { get; set; }
        public decimal Total { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}

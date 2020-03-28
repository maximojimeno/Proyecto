using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Cotizaciones
    {
        public int CotizacionId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public int NumeroCotizacion { get; set; }
        public decimal? Descuento { get; set; }
        public double? ImpuestoTotal { get; set; }
        public int? Total { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}

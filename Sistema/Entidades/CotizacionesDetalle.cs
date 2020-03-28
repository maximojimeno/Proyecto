using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class CotizacionesDetalle
    {
        public int CotizacionId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Cotizaciones Cotizacion { get; set; }
    }
}

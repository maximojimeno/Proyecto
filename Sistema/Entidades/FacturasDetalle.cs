using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class FacturasDetalle
    {
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double? Impuesto { get; set; }
        public int Precio { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Facturas Factura { get; set; }
    }
}

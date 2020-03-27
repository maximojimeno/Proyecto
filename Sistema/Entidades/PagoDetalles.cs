using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class PagoDetalles
    {
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaPago { get; set; }
        public string TipoPago { get; set; }
        public decimal MontoPago { get; set; }

        public virtual Facturas Factura { get; set; }
        public virtual Pagos Pago { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class PagosDetalle
    {
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public decimal Monto { get; set; }

        public virtual Facturas Factura { get; set; }
        public virtual Pagos Pago { get; set; }
    }
}

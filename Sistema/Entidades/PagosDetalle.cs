using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades
{
    public partial class PagosDetalle
    {
        [Key]
        public int PagosDetalleId {get;set;}

        public int PagoId { get; set; }
        public int FacturaId { get; set; }

        public int NumeroFactura { get; set; }
        public decimal Monto { get; set; }

        public virtual Facturas Factura { get; set; }
        public virtual Pagos Pago { get; set; }
    }
}

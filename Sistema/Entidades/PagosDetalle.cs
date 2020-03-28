using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades
{
    public partial class PagosDetalle
    {
        public PagosDetalle()
        {
            PagosDetalleId = 0;
            PagoId = 0;
            FacturaId = 0;
            NumeroFactura = 0;
            Monto = 0;
        }
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

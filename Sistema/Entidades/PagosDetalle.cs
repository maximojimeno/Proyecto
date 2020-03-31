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
            Total = 0;
        }
        [Key]
        public int PagosDetalleId {get;set;}
        public int PagoId { get; set; }
        public int FacturaId { get; set; }
        public decimal Total { get; set; }
        public virtual Facturas Factura { get; set; }
        public virtual Pagos Pago { get; set; }
    }
}

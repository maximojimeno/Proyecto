using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades
{
    public partial class CotizacionesDetalle
    {
        public CotizacionesDetalle()
        {
            CotizaconesDetalleId = 0;
            CotizacionId = 0;
            ArticuloId = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Costo = 0;
            Impuesto = 0;
            Precio = 0;
            Cantidad = 0;
        }
        [Key]
        public int CotizaconesDetalleId { get; set; }
        public int CotizacionId { get; set; }
        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Cotizaciones Cotizacion { get; set; }
    }
}
